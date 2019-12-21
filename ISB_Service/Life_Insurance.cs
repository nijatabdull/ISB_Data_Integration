using ISB_Model.Model;
using ISB_Model.Model.Life_Insurance_Model;
using ISB_Service.EF;
using ISB_Service.Infrastructure;
using ISB_Service.Model.RequestResponse;
using ISB_Service.Model.ViewModel;
using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISB_Service
{
    public partial class Life_Insurance : Form
    {
        private static readonly Logger FileLogger = LogManager.GetLogger("logFile");
        private static readonly Logger DbLogger = LogManager.GetLogger("databaseLogger");

        private string _Username { get; set; }
        private string _Userpassword { get; set; }

        public Life_Insurance()
        {
            InitializeComponent();

            if (ConfigurationManager.AppSettings["InsuranceType"] == "heyat")
            {
                _Username = ConfigurationManager.AppSettings["Username"];
                _Userpassword = ConfigurationManager.AppSettings["Userpassord"];
            }

            try
            {
                Task.Run(async () => {

                    //yyyymmddhhmmssfff
                    string requestNumber = DateTime.Now.ToString("yyyymmddhhmmss000");

                    ISB_Login_Request ISB_Login_Request = new ISB_Login_Request()
                    {
                        CompId = "isb",
                        RequestNumber = requestNumber,
                        Username = _Username,
                        Userpassword = _Userpassword
                    };

                    ISB_Login_Response ISB_Login_Response = await ServiceProvider
                                .PostDataAsync<LoginResponseViewModel>(ISB_Login_Request,
                                        "https://api.isb.az/dispatcher/gateway/aas/loginApi");

                    ClipContractInfo_Request clipContractInfo_Request = new ClipContractInfo_Request()
                    {
                        CompId = "isb",
                        RequestNumber = requestNumber,
                        FilterViewModel = new FilterViewModel()
                        {
                            InsCompanyCode = "",
                            AddendumNumber = "",
                            ContractNumber = "",
                            StartDate = "20190801",
                            ContractType = "",
                            EmployeeIdn = "",
                            EmployerIdn = "",
                            EmployerTaxId = "",
                            EndDate = "20191231",
                            RenewalNumber = ""
                        },
                        Token = ISB_Login_Response.Token
                    };

                    ClipContractInfo_Response clipContractInfo_Response = await ServiceProvider
                                .PostDataAsync<ClipContractInfo_Response>(clipContractInfo_Request,
                                     "https://api.isb.az/dispatcher/gateway/migration/clipContractInfo");

                    ClipContractWithDetail_Request clipContractWithDetail_Request = new ClipContractWithDetail_Request()
                    {
                        CompId = "isb",
                        FilterViewModel = new FilterViewModel()
                        {
                            InsCompanyCode = "",
                            AddendumNumber = "",
                            ContractNumber = "",
                            StartDate = "20190801",
                            ContractType = "",
                            EmployeeIdn = "",
                            EmployerIdn = "",
                            EmployerTaxId = "",
                            EndDate = "20191231",
                            RenewalNumber = ""
                        },
                        RequestNumber = requestNumber,
                        Token = clipContractInfo_Response.Token
                    };

                    ClipContractWithDetail_Response contractWithDetail_Response = await ServiceProvider
                                .PostDataAsync<ClipContractWithDetail_Response>(clipContractWithDetail_Request,
                                     "https://api.isb.az/dispatcher/gateway/migration/clipContractWithDetail");


                    IEnumerable<ISB_ContractList_Life> iSB_ContractList_Lifes = contractWithDetail_Response.ContractList;

                    using (DbEntity dbEntity = new DbEntity())
                    {
                        foreach (ISB_ContractList_Life iSB_ContractList in iSB_ContractList_Lifes)
                        {
                            dbEntity.ISB_ContractLists.Add(iSB_ContractList);

                            dbEntity.SaveChanges();
                        }
                    }

                }).Wait();
            }
            catch (AggregateException common)
            {
                foreach (Exception exception in common.InnerExceptions)
                {
                    DbLogger.Error(exception);
                    FileLogger.Error(exception);
                }
            }
            catch (SqlException exception)
            {
                DbLogger.Error(exception);
                FileLogger.Error(exception);
            }
            catch (NullReferenceException exception)
            {
                DbLogger.Error(exception);
                FileLogger.Error(exception);
            }
            catch (Exception exception)
            {
                DbLogger.Error(exception);
                FileLogger.Error(exception);
            }
        }
    }
}
