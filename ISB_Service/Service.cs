using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISB_Model.Model;
using ISB_Service.Infrastructure;
using ISB_Service.Model.Log;
using ISB_Service.Model.RequestResponse;
using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using NLog;

namespace ISB_Service
{
    public partial class Service : Form
    {
        private static readonly Logger FileLogger = LogManager.GetLogger("logFile");
        private static readonly Logger DbLogger = LogManager.GetLogger("databaseLogger");

        private string _Username { get; set; } 
        private string _Userpassword { get; set; }
        private string _CompId { get; set; } = "isb";

        public Service()
        {
            InitializeComponent();

            IEnumerable<Verbal> verbals = null;
            IEnumerable<Incident> incidents = null;
            IEnumerable<Claim> claims = null;
            IEnumerable<Payment> payments = null;

            Task.Run(async () =>
            {
                verbals = await DatabaseProvider
                                        .GetDataListAsync<Verbal>();

                incidents = await DatabaseProvider
                                        .GetDataListAsync<Incident>();

                claims = await DatabaseProvider
                                        .GetDataListAsync<Claim>();

                payments = await DatabaseProvider
                                        .GetDataListAsync<Payment>();
            }).Wait();

            verbal_grd.DataSource = verbals;
            incident_grd.DataSource = incidents;
            claim_grd.DataSource = claims;
            payment_grd.DataSource = payments;
        }

        private void StartSendData()
        {
            try
            {
                Task.Run(async () =>
                {
                    #region Verbal Section
                    IEnumerable<Verbal> verbals = await DatabaseProvider
                        .GetDataListAsync<Verbal>(x => x.IsPosted == false);

                    if (verbals?.Count() != 0)
                    {
                        foreach (Verbal verbal in verbals)
                        {
                            string appName = "PG_HIS_VERBAL";
                            string requestNumber = string.Empty;

                            if (verbal.DocumentId == null || verbal.DocumentId == string.Empty)
                            {
                                //yyyymmddhhmmssfff
                                requestNumber = DateTime.Now.ToString("yyyymmddhhmmssfff");
                            }
                            else
                                requestNumber = verbal.RequestNumber;


                            ISB_Login_Request ISB_Login_Request = new ISB_Login_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = requestNumber,
                                Username = _Username,
                                Userpassword = _Userpassword
                            };

                            ISB_Login_Response ISB_Login_Response = await ServiceProvider
                                        .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request,
                                                "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                            Oid_Request oid_Request = new Oid_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = requestNumber,
                                Token = ISB_Login_Response?.Token,
                                Count = 1
                            };

                            Oid_Response oid_Response = await ServiceProvider
                                        .PostDataAsync<Oid_Response>(oid_Request,
                                                "https://api.isb.az/dispatcher/gateway/integ/oid");

                            verbal.Oid = oid_Response?.Oid?.FirstOrDefault();

                            ISB_GenerateXhtml_Request ISB_GenerateXhtml_Request = new ISB_GenerateXhtml_Request()
                            {
                                CompId = ISB_Login_Request?.CompId,
                                RequestNumber = ISB_Login_Request?.RequestNumber,
                                Token = ISB_Login_Response?.Token,
                                JsonStr = JsonConvert.SerializeObject(new { verbal }),
                                AppName = appName
                            };

                            ISB_GenerateXhtml_Response ISB_GenerateXhtml_Response = await ServiceProvider
                                        .PostDataAsync<GenerateXhtmlResponseViewModel>(ISB_GenerateXhtml_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/generateXhtml");

                            ISB_CallService_Request iSB_CallService_Request = new ISB_CallService_Request()
                            {
                                CompId = ISB_GenerateXhtml_Request?.CompId,
                                RequestNumber = ISB_GenerateXhtml_Request?.RequestNumber,
                                Module = "migration",
                                Token = ISB_GenerateXhtml_Request?.Token,
                                Content = new CallServiceContentViewModel[]
                                {
                                    new CallServiceContentViewModel()
                                    {
                                        ApplicationName = ISB_GenerateXhtml_Request?.AppName,
                                        DataToParse = ISB_GenerateXhtml_Response?.XhtmlBase64,
                                        IsData = 1,
                                        IsMain = 1,
                                        DocOid = verbal?.DocumentId,
                                        FileId = "",
                                        FileType = "",
                                        ToAccount = ""
                                    }
                                }
                            };


                            ISB_CallService_Response iSB_CallService_Response = await ServiceProvider
                                        .PostDataAsync<ISB_CallService_Response>(iSB_CallService_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/callService");

                            ISB_CheckStatus_Request iSB_CheckStatus_Request = new ISB_CheckStatus_Request()
                            {
                                Token = ISB_GenerateXhtml_Response?.Token,
                                CompId = ISB_GenerateXhtml_Request?.CompId,
                                Oid = iSB_CallService_Response?.Oid,
                                RequestNumber = ISB_GenerateXhtml_Request?.RequestNumber
                            };

                            Thread.Sleep(2000);

                            ISB_CheckStatus_Response ISB_CheckStatus_Response = await ServiceProvider
                                        .PostDataAsync<CheckStatusResponseViewModel>(iSB_CheckStatus_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/checkStatus");

                            if (ISB_CheckStatus_Response.DocumentId != null &&
                                ISB_CheckStatus_Response.DocumentNumber != null)
                            {
                                verbal.RequestNumber = iSB_CheckStatus_Request.RequestNumber;
                                verbal.DocumentId = ISB_CheckStatus_Response.DocumentId;
                                verbal.DocumentNumber = ISB_CheckStatus_Response.DocumentNumber;
                                verbal.IsPosted = true;
                                verbal.CheckStatusOid = ISB_CheckStatus_Response.Oid;

                                await DatabaseProvider.UpdateDataAsync(verbal, x => x.ApplicationId == verbal.ApplicationId);
                            }
                            else
                            {
                                DbLogger.Warn("Verbal DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t ApplicationId: " + verbal.ApplicationId);
                                FileLogger.Warn("Verbal DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t ApplicationId: " + verbal.ApplicationId);
                            }
                        }
                    }

                    IEnumerable<Verbal> verbalss = await DatabaseProvider.GetDataListAsync<Verbal>();

                    if (InvokeRequired)
                    {
                        Invoke((Action)delegate ()
                       {
                           verbal_grd.DataSource = verbalss;
                       });
                    }

                    #endregion

                    #region Incident Section
                    IEnumerable<Incident> incidents = await DatabaseProvider
                                .GetDataListAsync<Incident>(x => x.IsPosted == false);

                    if (incidents.Count() != 0)
                    {
                        foreach (Incident incident in incidents)
                        {
                            int incidentRelateTableCount = 8;
                            int oidIncidentIndex = 0;

                            incident.InsurancePolicy = await DatabaseProvider
                                .GetFirstDataAsync<InsurancePolicy>(x => x.NOTICE_ID == incident.NOTICE_ID);

                            if (incident.InsurancePolicy != null)
                            {
                                incident.InsurancePolicy.Person = await DatabaseProvider
                                    .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.InsurancePolicy.NOTICE_ID);

                                incident.InsurancePolicy.Vehicle = await DatabaseProvider
                                    .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == incident.InsurancePolicy.NOTICE_ID);
                            }

                            incident.Vehicle = await DatabaseProvider
                                    .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == incident.NOTICE_ID);

                            incident.Person = await DatabaseProvider
                                .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.NOTICE_ID);

                            //incident.Witnesses.WitnessList = (await DatabaseProvider
                            //    .GetDataListAsync<WitnessList>(x => x.NOTICE_ID == incident.NOTICE_ID))?.ToList();

                            incident.IncidentDetail = await DatabaseProvider
                                .GetFirstDataAsync<IncidentDetail>(x => x.NOTICE_ID == incident.NOTICE_ID);

                            incident.IncidentDamager = await DatabaseProvider
                                .GetFirstDataAsync<IncidentDamager>(x => x.NOTICE_ID == incident.NOTICE_ID);

                            if (incident.IncidentDamager != null)
                            {
                                incident.IncidentDamager.Person = await DatabaseProvider
                                    .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.IncidentDamager.NOTICE_ID);
                            }

                            incident.DamagedPersons = (await DatabaseProvider
                                .GetDataListAsync<DamagedPerson>(x => x.NOTICE_ID == incident.NOTICE_ID)).ToList();


                            if (incident.DamagedPersons.Count != 0)
                            {
                                incidentRelateTableCount += incident.DamagedPersons.Count;

                                foreach (DamagedPerson damagedPerson in incident.DamagedPersons)
                                {
                                    damagedPerson.Person = await DatabaseProvider
                                        .GetFirstDataAsync<Person>(x => x.NOTICE_ID == damagedPerson.NOTICE_ID);

                                    damagedPerson.DamageList = (await DatabaseProvider
                                        .GetDataListAsync<DamageList>(x => x.NOTICE_ID == damagedPerson.NOTICE_ID))?.ToList();

                                    if (damagedPerson.DamageList.Count != 0)
                                    {
                                        incidentRelateTableCount += damagedPerson.DamageList.Count;

                                        foreach (DamageList damage in damagedPerson.DamageList)
                                        {
                                            damage.Vehicle = await DatabaseProvider
                                                .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == damage.NOTICE_ID);
                                        }
                                    }
                                }
                            }

                            incident.Attachments = (await DatabaseProvider
                                        .GetDataListAsync<Attachment>(x => x.NOTICE_ID == incident.NOTICE_ID))?.ToList();

                            incidentRelateTableCount += incident.Attachments.Count;

                            string requestNumber = string.Empty;

                            if (incident.DocumentId == null || incident.DocumentId == string.Empty)
                            {
                                //yyyymmddhhmmssfff
                                requestNumber = DateTime.Now.ToString("yyyymmddhhmmssfff");
                            }
                            else
                                requestNumber = incident.RequestNumber;

                            ISB_Login_Request ISB_Login_Request = new ISB_Login_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = requestNumber,
                                Username = _Username,
                                Userpassword = _Userpassword
                            };

                            ISB_Login_Response ISB_Login_Response = await ServiceProvider
                                        .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request,
                                                "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                            string appName = "PG_HIS_INCIDENT";

                            Oid_Request oid_Request = new Oid_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = requestNumber,
                                Token = ISB_Login_Response.Token,
                                Count = incidentRelateTableCount
                            };

                            Oid_Response oid_Response = await ServiceProvider
                                        .PostDataAsync<Oid_Response>(oid_Request,
                                                "https://api.isb.az/dispatcher/gateway/integ/oid");

                            string[] oidList = oid_Response?.Oid?.ToArray();

                            incident.Oid = oidList[oidIncidentIndex++];
                            incident.IncidentOid = incident.Oid;

                            if (incident.Person != null)
                            {
                                incident.Person.Oid = oidList[oidIncidentIndex++];
                            }

                            if (incident.Vehicle != null)
                                incident.Vehicle.VehicleOid = oidList[oidIncidentIndex++];

                            if (incident.InsurancePolicy != null)
                            {
                                incident.InsurancePolicy.Oid = oidList[oidIncidentIndex++];

                                if (incident.InsurancePolicy.Person != null)
                                {
                                    incident.InsurancePolicy.Person.Oid = incident?.Person?.Oid;
                                    incident.InsurancePolicy.PersonOid = incident?.Person?.Oid;
                                }
                                   

                                if (incident.InsurancePolicy.Vehicle != null)
                                {
                                    incident.InsurancePolicy.Vehicle.VehicleOid = incident?.Vehicle?.VehicleOid;
                                    incident.InsurancePolicy.VehicleOid = incident?.Vehicle?.VehicleOid;
                                }
                                   
                            }

                            if (incident.IncidentDamager != null)
                            {
                                incident.IncidentDamager.Oid = oidList[oidIncidentIndex++];

                                if (incident.IncidentDamager.Person != null)
                                {
                                    incident.IncidentDamager.Person.Oid = incident?.Person?.Oid;
                                    incident.IncidentDamager.PersonOid = incident?.Person?.Oid;
                                }
                            }

                            if (incident.IncidentDetail != null)
                                incident.IncidentDetail.Oid = oidList[oidIncidentIndex++];

                            if (incident.DamagedPersons.Count != 0)
                            {
                                foreach (DamagedPerson damaged in incident.DamagedPersons)
                                {
                                    damaged.Oid = oidList[oidIncidentIndex++];
                                    damaged.IncidentOid = incident.Oid;

                                    if (damaged.Person != null)
                                        damaged.Person.Oid = incident?.Person?.Oid;

                                    if (damaged.DamageList.Count != 0)
                                    {
                                        foreach (DamageList damageList in damaged.DamageList)
                                        {
                                            damageList.Oid = oidList[oidIncidentIndex++];
                                            damageList.DamageOid = damaged.Oid;

                                            if (damageList.Vehicle != null)
                                                damageList.Vehicle.VehicleOid = incident.Vehicle?.VehicleOid;
                                        }
                                    }
                                }
                            }

                            if (incident.Attachments.Count != 0)
                            {
                                foreach (Attachment attachment in incident.Attachments)
                                {
                                    attachment.IncidentOid = incident.Oid;
                                }
                            }

                            incident.PersonOid = incident?.Person?.Oid;
                            incident.VehicleOid = incident?.Vehicle?.VehicleOid;
                            incident.InsurancePolicyOid = incident?.InsurancePolicy?.Oid;
                            incident.IncidentDamagerOid = incident?.IncidentDamager?.Oid;
                            incident.IncidentDetailOid = incident?.IncidentDetail?.Oid;

                            ISB_GenerateXhtml_Request ISB_GenerateXhtml_Request = new ISB_GenerateXhtml_Request()
                            {
                                CompId = ISB_Login_Request.CompId,
                                RequestNumber = ISB_Login_Request.RequestNumber,
                                Token = ISB_Login_Response.Token,
                                JsonStr = JsonConvert.SerializeObject(new { incident }),
                                AppName = appName
                            };

                            ISB_GenerateXhtml_Response ISB_GenerateXhtml_Response = await ServiceProvider
                                        .PostDataAsync<GenerateXhtmlResponseViewModel>(ISB_GenerateXhtml_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/generateXhtml");

                            ISB_CallService_Request iSB_CallService_Request = new ISB_CallService_Request()
                            {
                                CompId = ISB_GenerateXhtml_Request?.CompId,
                                RequestNumber = ISB_GenerateXhtml_Request?.RequestNumber,
                                Module = "migration",
                                Token = ISB_GenerateXhtml_Request?.Token,
                                Content = new CallServiceContentViewModel[]
                                {
                                    new CallServiceContentViewModel()
                                    {
                                        ApplicationName = ISB_GenerateXhtml_Request?.AppName,
                                        DataToParse = ISB_GenerateXhtml_Response?.XhtmlBase64,
                                        IsData = 1,
                                        IsMain = 1,
                                        DocOid = incident?.DocumentId,
                                        FileId = "",
                                        FileType = "",
                                        ToAccount = ""
                                    }
                                }
                            };

                            ISB_CallService_Response iSB_CallService_Response = await ServiceProvider
                                        .PostDataAsync<ISB_CallService_Response>(iSB_CallService_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/callService");

                            ISB_CheckStatus_Request iSB_CheckStatus_Request = new ISB_CheckStatus_Request()
                            {
                                Token = ISB_GenerateXhtml_Response.Token,
                                CompId = ISB_GenerateXhtml_Request.CompId,
                                Oid = iSB_CallService_Response.Oid,
                                RequestNumber = ISB_GenerateXhtml_Request.RequestNumber
                            };

                            Thread.Sleep(2000);

                            ISB_CheckStatus_Response ISB_CheckStatus_Response = await ServiceProvider
                                        .PostDataAsync<CheckStatusResponseViewModel>(iSB_CheckStatus_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/checkStatus");

                            if (ISB_CheckStatus_Response.DocumentId != null &&
                                    ISB_CheckStatus_Response.DocumentNumber != null)
                            {
                                incident.RequestNumber = iSB_CheckStatus_Request.RequestNumber;
                                incident.DocumentId = ISB_CheckStatus_Response.DocumentId;
                                incident.DocumentNumber = ISB_CheckStatus_Response.DocumentNumber;
                                incident.IsPosted = true;
                                incident.CheckStatusOid = ISB_CheckStatus_Response.Oid;
                                incident.IncidentDocOid = ISB_CheckStatus_Response.DocumentId;

                                await DatabaseProvider.UpdateDataAsync(incident, x => x.NOTICE_ID == incident.NOTICE_ID);

                                if (incident.Person != null)
                                    await DatabaseProvider.UpdateDataAsync(incident.Person, x => x.NOTICE_ID == incident.Person.NOTICE_ID);

                                if (incident.Vehicle != null)
                                    await DatabaseProvider.UpdateDataAsync(incident.Vehicle, x => x.NOTICE_ID == incident.Vehicle.NOTICE_ID);

                                if (incident.InsurancePolicy != null)
                                {
                                    await DatabaseProvider.UpdateDataAsync(incident.InsurancePolicy, x => x.NOTICE_ID == incident.InsurancePolicy.NOTICE_ID);

                                    if (incident.InsurancePolicy.Person != null)
                                        await DatabaseProvider.UpdateDataAsync(incident.InsurancePolicy.Person, x => x.NOTICE_ID == incident.InsurancePolicy.Person.NOTICE_ID);

                                    if (incident.InsurancePolicy.Vehicle != null)
                                        await DatabaseProvider.UpdateDataAsync(incident.InsurancePolicy.Vehicle, x => x.NOTICE_ID == incident.InsurancePolicy.Vehicle.NOTICE_ID);
                                }

                                if (incident.IncidentDamager != null)
                                {
                                    await DatabaseProvider.UpdateDataAsync(incident.IncidentDamager, x => x.NOTICE_ID == incident.IncidentDamager.NOTICE_ID);

                                    if (incident.IncidentDamager.Person != null)
                                        await DatabaseProvider.UpdateDataAsync(incident.IncidentDamager.Person, x => x.NOTICE_ID == incident.IncidentDamager.Person.NOTICE_ID);
                                }

                                if (incident.IncidentDetail != null)
                                    await DatabaseProvider.UpdateDataAsync(incident.IncidentDetail, x => x.NOTICE_ID == incident.IncidentDetail.NOTICE_ID);

                                if (incident.DamagedPersons.Count != 0)
                                {
                                    foreach (DamagedPerson damaged in incident.DamagedPersons)
                                    {
                                        await DatabaseProvider.UpdateDataAsync(damaged, x => x.NOTICE_ID == damaged.NOTICE_ID);

                                        if (damaged.Person != null)
                                            await DatabaseProvider.UpdateDataAsync(damaged.Person, x => x.NOTICE_ID == damaged.Person.NOTICE_ID);

                                        if (damaged.DamageList.Count != 0)
                                        {
                                            foreach (DamageList damageList in damaged.DamageList)
                                            {
                                                await DatabaseProvider.UpdateDataAsync(damageList, x => x.NOTICE_ID == damageList.NOTICE_ID);

                                                if (damageList.Vehicle != null)
                                                    await DatabaseProvider.UpdateDataAsync(damageList.Vehicle, x => x.NOTICE_ID == damageList.NOTICE_ID);
                                            }
                                        }
                                    }
                                }

                                if (incident.Attachments.Count != 0)
                                {
                                    foreach (Attachment attachment in incident.Attachments)
                                    {
                                        await DatabaseProvider.UpdateDataAsync(attachment, x => x.NOTICE_ID == attachment.NOTICE_ID);
                                    }
                                }
                            }
                            else
                            {
                                DbLogger.Warn("Incident DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t NOTICE_ID: " + incident.NOTICE_ID);
                                FileLogger.Warn("Incident DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t NOTICE_ID: " + incident.NOTICE_ID);
                            }
                        }
                    }

                    IEnumerable<Incident> incidentss = await DatabaseProvider.GetDataListAsync<Incident>();

                    if (InvokeRequired)
                    {
                        Invoke((Action)delegate ()
                       {
                           incident_grd.DataSource = incidentss;
                       });
                    }

                    #endregion

                    #region Claim Section
                    IEnumerable<Claim> claims = await DatabaseProvider
                        .GetDataListAsync<Claim>(x => x.IsPosted == false);

                    if (claims.Count() != 0)
                    {
                        foreach (Claim claim in claims)
                        {
                            int claimRelateTableCount = 8;
                            int oidClaimtIndex = 0;

                            claim.Person = await DatabaseProvider
                                .GetFirstDataAsync<Person>(x => x.NOTICE_ID == claim.NOTICE_ID);

                            claim.DamagedPerson = await DatabaseProvider
                                .GetFirstDataAsync<DamagedPerson>(x => x.NOTICE_ID == claim.NOTICE_ID);

                            if (claim.DamagedPerson != null)
                            {
                                claim.DamagedPerson.Person = await DatabaseProvider
                                        .GetFirstDataAsync<Person>(x => x.NOTICE_ID == claim.DamagedPerson.NOTICE_ID);

                                claim.DamagedPerson.DamageList = (await DatabaseProvider.
                                    GetDataListAsync<DamageList>(x => x.NOTICE_ID == claim.DamagedPerson.NOTICE_ID))?.ToList();

                                if (claim.DamagedPerson.DamageList.Count != 0)
                                {
                                    foreach (DamageList damageList in claim.DamagedPerson.DamageList)
                                    {
                                        damageList.Vehicle = await DatabaseProvider
                                            .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == damageList.NOTICE_ID);
                                    }
                                }
                            }

                            claim.Attachments = (await DatabaseProvider.
                                GetDataListAsync<Attachment>(x => x.NOTICE_ID == claim.NOTICE_ID))?.ToList();

                            claim.Beneficiary = (await DatabaseProvider.
                                GetDataListAsync<Beneficiary>(x => x.NOTICE_ID == claim.NOTICE_ID))?.ToList();

                            if (claim.Beneficiary.Count() != 0)
                            {
                                claimRelateTableCount += claim.Beneficiary.Count();

                                foreach (Beneficiary beneficiary in claim.Beneficiary)
                                {
                                    beneficiary.Person = await DatabaseProvider
                                        .GetFirstDataAsync<Person>(x => x.NOTICE_ID == beneficiary.NOTICE_ID);
                                }
                            }

                            Incident incident = await DatabaseProvider
                                .GetFirstDataAsync<Incident>((x, y) => x.NOTICE_ID == claim.NOTICE_ID && y.IsPosted == true);

                            if (incident != null)
                            {
                                incident.InsurancePolicy = await DatabaseProvider
                                    .GetFirstDataAsync<InsurancePolicy>(x => x.NOTICE_ID == incident.NOTICE_ID);

                                if (incident.InsurancePolicy != null)
                                {
                                    incident.InsurancePolicy.Person = await DatabaseProvider
                                        .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.InsurancePolicy.NOTICE_ID);

                                    incident.InsurancePolicy.Vehicle = await DatabaseProvider
                                        .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == incident.InsurancePolicy.NOTICE_ID);
                                }


                                incident.Vehicle = await DatabaseProvider
                                        .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == incident.NOTICE_ID);

                                incident.Person = await DatabaseProvider
                                    .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.NOTICE_ID);

                                //incident.Witnesses.WitnessList = (await DatabaseProvider
                                //    .GetDataListAsync<WitnessList>(x => x.NOTICE_ID == incident.NOTICE_ID))?.ToList();

                                incident.IncidentDetail = await DatabaseProvider
                                    .GetFirstDataAsync<IncidentDetail>(x => x.NOTICE_ID == incident.NOTICE_ID);

                                incident.IncidentDamager = await DatabaseProvider
                                    .GetFirstDataAsync<IncidentDamager>(x => x.NOTICE_ID == incident.NOTICE_ID);

                                if (incident.IncidentDamager != null)
                                {
                                    incident.IncidentDamager.Person = await DatabaseProvider
                                        .GetFirstDataAsync<Person>(x => x.NOTICE_ID == incident.IncidentDamager.NOTICE_ID);
                                }

                                incident.DamagedPersons = (await DatabaseProvider
                                    .GetDataListAsync<DamagedPerson>(x => x.NOTICE_ID == incident.NOTICE_ID)).ToList();


                                if (incident.DamagedPersons.Count != 0)
                                {
                                    foreach (DamagedPerson damagedPerson in incident.DamagedPersons)
                                    {
                                        damagedPerson.Person = await DatabaseProvider
                                            .GetFirstDataAsync<Person>(x => x.NOTICE_ID == damagedPerson.NOTICE_ID);

                                        damagedPerson.DamageList = (await DatabaseProvider
                                            .GetDataListAsync<DamageList>(x => x.NOTICE_ID == damagedPerson.NOTICE_ID))?.ToList();

                                        if (damagedPerson.DamageList.Count != 0)
                                        {
                                            foreach (DamageList damage in damagedPerson.DamageList)
                                            {
                                                damage.Vehicle = await DatabaseProvider
                                                    .GetFirstDataAsync<Vehicle>(x => x.NOTICE_ID == damage.NOTICE_ID);
                                            }
                                        }
                                    }
                                }

                                incident.Attachments = (await DatabaseProvider
                                            .GetDataListAsync<Attachment>(x => x.NOTICE_ID == incident.NOTICE_ID))?.ToList();

                                claim.IncidentDocOid = incident?.DocumentId;


                                string requestNumber = string.Empty;

                                if (claim.DocumentId == null || claim.DocumentId == string.Empty)
                                {
                                    //yyyymmddhhmmssfff
                                    requestNumber = DateTime.Now.ToString("yyyymmddhhmmssfff");
                                }
                                else
                                    requestNumber = claim.RequestNumber;

                                ISB_Login_Request ISB_Login_Request = new ISB_Login_Request()
                                {
                                    CompId = _CompId,
                                    RequestNumber = requestNumber,
                                    Username = _Username,
                                    Userpassword = _Userpassword
                                };

                                ISB_Login_Response ISB_Login_Response = await ServiceProvider
                                            .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request,
                                                    "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                                string appName = "PG_HIS_CLAIM_APPLICANT";

                                Oid_Request oid_Request = new Oid_Request()
                                {
                                    CompId = _CompId,
                                    RequestNumber = requestNumber,
                                    Token = ISB_Login_Response.Token,
                                    Count = claimRelateTableCount + 1
                                };

                                Oid_Response oid_Response = await ServiceProvider
                                            .PostDataAsync<Oid_Response>(oid_Request,
                                                    "https://api.isb.az/dispatcher/gateway/integ/oid");

                                string[] oidList = oid_Response?.Oid?.ToArray();

                                claim.ClaimOid = oidList[oidClaimtIndex++];
                                claim.IncidentOid = incident?.Oid;
                                claim.PersonOid = incident?.PersonOid;
                                claim.DamagedPersonOid = incident?.DamagedPersons?.FirstOrDefault()?.Oid;

                                if (claim.Beneficiary.Count != 0)
                                {
                                    foreach (Beneficiary beneficiary in claim.Beneficiary)
                                    {
                                        beneficiary.Oid = oidList[oidClaimtIndex++];
                                        beneficiary.ClaimOid = claim.ClaimOid;
                                        beneficiary.PersonOid = incident?.PersonOid;
                                    }
                                }

                                ISB_GenerateXhtml_Request ISB_GenerateXhtml_Request = new ISB_GenerateXhtml_Request()
                                {
                                    CompId = ISB_Login_Request.CompId,
                                    RequestNumber = ISB_Login_Request.RequestNumber,
                                    Token = ISB_Login_Response.Token,
                                    JsonStr = JsonConvert.SerializeObject(new
                                    {
                                        claim,
                                        incident
                                    }),
                                    AppName = appName
                                };

                                ISB_GenerateXhtml_Response ISB_GenerateXhtml_Response = await ServiceProvider
                                            .PostDataAsync<GenerateXhtmlResponseViewModel>(ISB_GenerateXhtml_Request,
                                                        "https://api.isb.az/dispatcher/gateway/integ/generateXhtml");

                                ISB_CallService_Request iSB_CallService_Request = new ISB_CallService_Request()
                                {
                                    CompId = ISB_GenerateXhtml_Request.CompId,
                                    RequestNumber = ISB_GenerateXhtml_Request.RequestNumber,
                                    Module = "migration",
                                    Token = ISB_GenerateXhtml_Response.Token,
                                    Content = new CallServiceContentViewModel[]
                                    {
                                            new CallServiceContentViewModel()
                                            {
                                                ApplicationName = ISB_GenerateXhtml_Request.AppName,
                                                DataToParse = ISB_GenerateXhtml_Response.XhtmlBase64,
                                                IsData = 1,
                                                IsMain = 1,
                                                DocOid = claim.DocumentId,
                                                FileId = "",
                                                FileType = "",
                                                ToAccount = ""
                                            }
                                    }
                                };

                                ISB_CallService_Response iSB_CallService_Response = await ServiceProvider
                                            .PostDataAsync<ISB_CallService_Response>(iSB_CallService_Request,
                                                        "https://api.isb.az/dispatcher/gateway/integ/callService");

                                ISB_CheckStatus_Request iSB_CheckStatus_Request = new ISB_CheckStatus_Request()
                                {
                                    CompId = ISB_GenerateXhtml_Request.CompId,
                                    RequestNumber = ISB_GenerateXhtml_Request.RequestNumber,
                                    Token = ISB_GenerateXhtml_Response.Token,
                                    Oid = iSB_CallService_Response.Oid
                                };

                                Thread.Sleep(2000);

                                ISB_CheckStatus_Response ISB_CheckStatus_Response = await ServiceProvider
                                            .PostDataAsync<CheckStatusResponseViewModel>(iSB_CheckStatus_Request,
                                                        "https://api.isb.az/dispatcher/gateway/integ/checkStatus");

                                if (ISB_CheckStatus_Response.DocumentId != null &&
                                    ISB_CheckStatus_Response.DocumentNumber != null)
                                {
                                    claim.RequestNumber = iSB_CheckStatus_Request.RequestNumber;
                                    claim.DocumentId = ISB_CheckStatus_Response.DocumentId;
                                    claim.DocumentNumber = ISB_CheckStatus_Response.DocumentNumber;
                                    claim.IsPosted = true;
                                    claim.CheckStatusOid = ISB_CheckStatus_Response.Oid;

                                    await DatabaseProvider.UpdateDataAsync(claim, x => x.NOTICE_ID == claim.NOTICE_ID);

                                    if (claim.Beneficiary.Count != 0)
                                    {
                                        foreach (Beneficiary beneficiary in claim.Beneficiary)
                                        {
                                            await DatabaseProvider.UpdateDataAsync(beneficiary, x => x.NOTICE_ID == beneficiary.NOTICE_ID);
                                        }
                                    }
                                }

                                DbLogger.Warn("Claim DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t NOTICE_ID: " + claim.NOTICE_ID + "\t CUSTOMER_ID: " + claim.CUSTOMER_ID);
                                FileLogger.Warn("Claim DocumentId: " + ISB_CheckStatus_Response.DocumentId + "\t Message: " + ISB_CheckStatus_Response.Message + "\t Errors: " + ISB_CheckStatus_Response.Errors + "\t NOTICE_ID: " + claim.NOTICE_ID + "\t CUSTOMER_ID: " + claim.CUSTOMER_ID);
                            }
                        }

                        IEnumerable<Claim> claimss = await DatabaseProvider.GetDataListAsync<Claim>();

                        if (InvokeRequired)
                        {
                            Invoke((Action)delegate ()
                           {
                               claim_grd.DataSource = claimss;
                           });
                        }
                    }
                    #endregion

                    #region Payment Section
                    IEnumerable<Payment> payments = (await DatabaseProvider
                            .GetDataListAsync<Payment>(x => x.IsPosted == false));

                    if (payments.Count() != 0)
                    {
                        foreach (Payment payment in payments)
                        {
                            #region Payment

                            string requestNumber = string.Empty;

                            if (payment.DocumentId == null || payment.DocumentId == string.Empty)
                            {
                                //yyyymmddhhmmssfff
                                requestNumber = DateTime.Now.ToString("yyyymmddhhmmssfff");
                            }
                            else
                                requestNumber = payment.RequestNumber;

                            ISB_Login_Request ISB_Login_Request_Payment = new ISB_Login_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = requestNumber,
                                Username = _Username,
                                Userpassword = _Userpassword
                            };

                            ISB_Login_Response ISB_Login_Response_Payment = await ServiceProvider
                                        .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request_Payment,
                                                "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                            string appName_Payment = "PG_HIS_PAYMENT_REQUEST";

                            ISB_GenerateXhtml_Request ISB_GenerateXhtml_Request_Payment = new ISB_GenerateXhtml_Request()
                            {
                                CompId = ISB_Login_Request_Payment.CompId,
                                RequestNumber = ISB_Login_Request_Payment.RequestNumber,
                                Token = ISB_Login_Response_Payment.Token,
                                JsonStr = JsonConvert.SerializeObject(new
                                {
                                    payment
                                }),
                                AppName = appName_Payment
                            };

                            ISB_GenerateXhtml_Response ISB_GenerateXhtml_Response_Payment = await ServiceProvider
                                        .PostDataAsync<GenerateXhtmlResponseViewModel>(ISB_GenerateXhtml_Request_Payment,
                                                    "https://api.isb.az/dispatcher/gateway/integ/generateXhtml");

                            ISB_CallService_Request iSB_CallService_Request_Payment = new ISB_CallService_Request()
                            {
                                CompId = ISB_GenerateXhtml_Request_Payment.CompId,
                                RequestNumber = ISB_GenerateXhtml_Request_Payment.RequestNumber,
                                Module = "migration",
                                Token = ISB_GenerateXhtml_Response_Payment.Token,
                                Content = new CallServiceContentViewModel[]
                                {
                                    new CallServiceContentViewModel()
                                    {
                                        ApplicationName = ISB_GenerateXhtml_Request_Payment.AppName,
                                        DataToParse = ISB_GenerateXhtml_Response_Payment.XhtmlBase64,
                                        IsData = 1,
                                        IsMain = 1,
                                        DocOid = payment.DocumentId,
                                        FileId = "",
                                        FileType = "",
                                        ToAccount = ""
                                    }
                                }
                            };

                            ISB_CallService_Response iSB_CallService_Response_Payment = await ServiceProvider
                                        .PostDataAsync<ISB_CallService_Response>(iSB_CallService_Request_Payment,
                                                    "https://api.isb.az/dispatcher/gateway/integ/callService");

                            ISB_CheckStatus_Request iSB_CheckStatus_Request_Payment = new ISB_CheckStatus_Request()
                            {
                                CompId = ISB_GenerateXhtml_Request_Payment.CompId,
                                RequestNumber = ISB_GenerateXhtml_Request_Payment.RequestNumber,
                                Token = ISB_GenerateXhtml_Response_Payment.Token,
                                Oid = iSB_CallService_Response_Payment.Oid
                            };

                            Thread.Sleep(2000);

                            ISB_CheckStatus_Response ISB_CheckStatus_Response_Payment = await ServiceProvider
                                        .PostDataAsync<CheckStatusResponseViewModel>(iSB_CheckStatus_Request_Payment,
                                                    "https://api.isb.az/dispatcher/gateway/integ/checkStatus");

                            if (ISB_CheckStatus_Response_Payment.DocumentId != null &&
                                ISB_CheckStatus_Response_Payment.DocumentNumber != null)
                            {
                                payment.RequestNumber = iSB_CheckStatus_Request_Payment.RequestNumber;
                                payment.DocumentId = ISB_CheckStatus_Response_Payment.DocumentId;
                                payment.DocumentNumber = ISB_CheckStatus_Response_Payment.DocumentNumber;
                                payment.IsPosted = true;
                                payment.CheckStatusOid = ISB_CheckStatus_Response_Payment.Oid;

                                await DatabaseProvider.UpdateDataAsync(payment, x => x.EXECUTIVE_ID == payment.EXECUTIVE_ID);
                            }
                            else
                            {
                                DbLogger.Warn("Payment DocumentId: " + ISB_CheckStatus_Response_Payment.DocumentId + "\t Message: " + ISB_CheckStatus_Response_Payment.Message + "\t Errors: " + ISB_CheckStatus_Response_Payment.Errors + "\t EXECUTIVE_ID: " + payment.EXECUTIVE_ID);
                                FileLogger.Warn("Payment DocumentId: " + ISB_CheckStatus_Response_Payment.DocumentId + "\t Message: " + ISB_CheckStatus_Response_Payment.Message + "\t Errors: " + ISB_CheckStatus_Response_Payment.Errors + "\t EXECUTIVE_ID: " + payment.EXECUTIVE_ID);
                            }

                            #endregion
                        }

                        IEnumerable<Payment> paymentss = await DatabaseProvider.GetDataListAsync<Payment>();

                        if (InvokeRequired)
                        {
                            Invoke((Action)delegate ()
                           {
                               payment_grd.DataSource = paymentss;
                           });
                        }
                    }
                    #endregion

                    #region Forma4 Section

                    IEnumerable<Incident> incidentsForForma4 = await DatabaseProvider
                            .GetDataListAsync<Incident>((x, y) => x.IsPosted == true && y.Forma4IsAccepted == false);

                    if (incidentsForForma4.Count() != 0)
                    {
                        foreach (Incident incident in incidentsForForma4)
                        {
                            ISB_Login_Request ISB_Login_Request = new ISB_Login_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = incident.RequestNumber,
                                Username = _Username,
                                Userpassword = _Userpassword
                            };

                            ISB_Login_Response ISB_Login_Response = await ServiceProvider
                                        .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request,
                                                "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                            Forma4_Request forma4_Request = new Forma4_Request()
                            {
                                CompId = _CompId,
                                RequestNumber = incident.RequestNumber,
                                Token = ISB_Login_Response.Token,
                                CarNumber = incident?.Plate,
                                IncidentDate = incident?.IncidentDate.Value.ToString("yyyyMMdd")
                            };

                            Forma4_Response forma4_Response = await ServiceProvider
                                        .PostDataAsync<Forma4_Response>(forma4_Request,
                                                "https://api.isb.az/dispatcher/gateway/migration/forma4");

                            if (forma4_Response.Forma4List != null)
                            {
                                foreach (Forma4List forma4List in forma4_Response?.Forma4List)
                                {
                                    if (forma4List.Forma4Attachments.Count != 0)
                                    {
                                        foreach (string attachment in forma4List?.Forma4Attachments)
                                        {
                                            GetAttach_Request getAttach_Request = new GetAttach_Request()
                                            {
                                                CompId = _CompId,
                                                Type = "forma4",
                                                RequestNumber = incident.RequestNumber,
                                                Token = forma4_Response.Token,
                                                FileId = attachment
                                            };

                                            GetAttach_Response getAttach_Response = await ServiceProvider
                                                .PostDataAsync<GetAttach_Response>(getAttach_Request,
                                                        "https://api.isb.az/dispatcher/gateway/migration/getAttach");

                                            //save to file

                                            //byte[] sPDFDecoded = Convert.FromBase64String(getAttach_Response.Base64Content);

                                            //string path = Path.Combine(Directory.GetCurrentDirectory() + "\\base64" + "\\" + attachment +"."+ getAttach_Response.FileExtension);

                                            //File.WriteAllBytes(path, sPDFDecoded);

                                            try
                                            {
                                                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager
                                                                .ConnectionStrings["FileServerConnection"].ConnectionString))
                                                {
                                                    await sqlConnection.OpenAsync().ConfigureAwait(false);

                                                    StringBuilder stringBuilder = new StringBuilder();

                                                    stringBuilder.Append("INSERT INTO ISB_FORMA4_FILES (NOTICE_ID,FILE_NAME,FILE_TYPE,FILE_CONTENT,DOC_NUMBER,CREATE_DATE) VALUES(");

                                                    stringBuilder.Append(incident?.NOTICE_ID + ",'");

                                                    stringBuilder.Append(attachment + "','");

                                                    stringBuilder.Append(getAttach_Response?.FileExtension + "','");

                                                    stringBuilder.Append(getAttach_Response?.Base64Content + "','");

                                                    stringBuilder.Append(forma4List?.DocNumber + "',");

                                                    stringBuilder.Append("GETDATE())");

                                                    using (SqlCommand sqlCommand = new SqlCommand(stringBuilder.ToString(), sqlConnection))
                                                    {
                                                        await sqlCommand.ExecuteNonQueryAsync();

                                                        await DatabaseProvider.UpdateDataAsync<Incident>(x => x.NOTICE_ID == incident.NOTICE_ID, z => z.Forma4IsAccepted, true);
                                                    }
                                                }
                                            }
                                            catch (AggregateException common)
                                            {
                                                foreach (Exception exp in common.InnerExceptions)
                                                {
                                                    FileLogger.Error(exp, exp.Message);
                                                    DbLogger.Error(exp, exp.Message);
                                                }
                                            }
                                            catch (SqlException exp)
                                            {
                                                FileLogger.Error(exp, exp.Message);
                                                DbLogger.Error(exp, exp.Message);
                                            }
                                            catch (Exception exp)
                                            {
                                                FileLogger.Error(exp, exp.Message);
                                                DbLogger.Error(exp, exp.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #endregion
                });
            }
            catch (AggregateException common)
            {
                foreach (Exception exp in common.InnerExceptions)
                {
                    FileLogger.Error(exp, exp.Message);
                    DbLogger.Error(exp, exp.Message);
                }
            }
            catch (SqlException exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
        }

        private void Error_btn_Click(object sender, EventArgs e)
        {
            Hide();

            ErrorLogger errorLogger = new ErrorLogger(this);

            errorLogger.Show();
        }

        private void SetErrorCount()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer
            {
                Interval = 10000
            };

            lblError.Padding = new Padding(0);

            timer.Tick += async (sender, e) =>
            {
                IEnumerable<Logs> logs = await DatabaseProvider.GetDataListAsync<Logs>(x => x.HasBeenSeen == false);

                if (logs.Count() !=0)
                    lblError.Text = logs.Count().ToString();
                else
                    lblError.Padding = new Padding(0);
            };

            timer.Start();
        }

        private void verbal_grd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in verbal_grd.Rows)
            {
                bool? IsPosted = Convert.ToBoolean(row.Cells["IsPosted"].Value);

                if (IsPosted == false || IsPosted == null)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else
                    row.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void incident_grd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in incident_grd.Rows)
            {
                bool? IsPosted = Convert.ToBoolean(row.Cells["IsPosted"].Value);

                if (IsPosted == false || IsPosted == null)
                    row.DefaultCellStyle.BackColor = Color.Red;
                else
                    row.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void Service_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["InsuranceType"] == "qeyri-heyat")
            {
                _Username = ConfigurationManager.AppSettings["Username"];
                _Userpassword = ConfigurationManager.AppSettings["Userpassord"];
            }

            try
            {
                SetErrorCount();

                StartSendData();

            }
            catch (AggregateException common)
            {
                foreach (Exception exp in common.InnerExceptions)
                {
                    FileLogger.Error(exp, exp.Message);
                    DbLogger.Error(exp, exp.Message);
                }
            }
            catch (SqlException exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }
            catch (Exception exp)
            {
                FileLogger.Error(exp, exp.Message);
                DbLogger.Error(exp, exp.Message);
            }

            System.Timers.Timer timer = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 1800000
            };

            timer.Start();

            //main section
            timer.Elapsed += (i, send) =>
            {
                StartSendData();
            };
        }
    }
}
