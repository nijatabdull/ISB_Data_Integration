using ISB_Model.Model.Life_Insurance_Model;
using ISB_Service.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.EF
{
    public class DbEntity : DbContext
    {
        public DbEntity() : base("name=IcbariSigortaBurosu") { }

        //Forma4
        //DbSet<CompletionStatus_Forma4> CompletionStatuses { get; set; }
        //DbSet<DamageType_Forma4> DamageTypes { get; set; }
        //DbSet<DriverStatus_Forma4> DriverStatuses { get; set; }
        //DbSet<DriverType_Forma4> DriverTypes { get; set; }
        //DbSet<Employee_Forma4> Employees { get; set; }
        //DbSet<Forma4List> Forma4Lists { get; set; }
        //DbSet<IncidentRegion_Forma4> IncidentRegions { get; set; }
        //DbSet<IncidentStatus_Forma4> IncidentStatuses { get; set; }
        //DbSet<IncidentTypeList_Forma4> IncidentTypeLists { get; set; }
        //DbSet<ParticipanType_Forma4> ParticipanTypes { get; set; }
        //DbSet<Person_Forma4> People { get; set; }
        //DbSet<PersonStatus_Forma4> PersonStatuses { get; set; }
        //DbSet<PersonType_Forma4> PersonTypes { get; set; }
        //DbSet<PersonWrapperList_Forma4> PersonWrapperLists { get; set; }
        //DbSet<TechnicalFailure_Forma4> TechnicalFailures { get; set; }
        //DbSet<Vehicle_Forma4> Vehicles { get; set; }
        //DbSet<VehicleType_Forma4> VehicleTypes { get; set; }
        //DbSet<VehicleWrapperList_Forma4> VehicleWrappers { get; set; }

        //Life insurance
        public DbSet<ISB_Address_Life> ISB_Addresses { get; set; }
        public DbSet<ISB_AuthPerson_Life> ISB_AuthPeople { get; set; }
        public DbSet<ISB_Bank_Life> ISB_Banks { get; set; }
        public DbSet<ISB_BankAccount_Life> ISB_BankAccounts { get; set; }
        public DbSet<ISB_BankBranch_Life> ISB_BankBranches { get; set; }
        public DbSet<ISB_Contact_Life> ISB_Contacts { get; set; }
        public DbSet<ISB_ContractList_Life> ISB_ContractLists { get; set; }
        public DbSet<ISB_Creditor_Life> ISB_Creditors { get; set; }
        public DbSet<ISB_CreditorAddress_Life> ISB_CreditorAddresses { get; set; }
        public DbSet<ISB_CreditorContact_Life> ISB_CreditorContacts { get; set; }
        public DbSet<ISB_Debitor_Life> ISB_Debitors { get; set; }
        public DbSet<ISB_DebitorAddress_Life> ISB_DebitorAddresses { get; set; }
        public DbSet<ISB_DebitorContact_Life> ISB_DebitorContacts { get; set; }
        public DbSet<ISB_DelegatedAuthPerson_Life> ISB_DelegatedAuthPeople { get; set; }
        public DbSet<ISB_EmployeeList_Life> ISB_EmployeeLists { get; set; }
        public DbSet<ISB_Employeer_Ancestor_Life> ISB_Employeer_Ancestors { get; set; }
        public DbSet<ISB_Employeer_Life> ISB_Employeers { get; set; }
        public DbSet<ISB_EmploymentList_Life> ISB_Employments { get; set; }
        public DbSet<ISB_InsBankAccount_Life> ISB_InsBankAccounts { get; set; }
        public DbSet<ISB_InstallmentList_Life> ISB_InstallmentLists { get; set; }
        public DbSet<ISB_Invoice_Life> ISB_Invoices { get; set; }
        public DbSet<ISB_PaymentList_Life> ISB_Payments { get; set; }
        public DbSet<ISB_Person_Life> ISB_People { get; set; }
        public DbSet<ISB_SignerPerson_Life> ISB_SignerPeople { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
            .HasRequired(c => c.Address)
                .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
            .HasRequired(c => c.AuthPerson)
                .WithMany()
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
          .HasRequired(c => c.BankAccount)
              .WithMany()
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
          .HasRequired(c => c.Contact)
              .WithMany()
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
          .HasRequired(c => c.DelegatedAuthPerson)
              .WithMany()
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
          .HasRequired(c => c.Employeer)
              .WithMany()
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<ISB_Employeer_Ancestor_Life>()
          .HasRequired(c => c.SignerPerson)
              .WithMany()
                  .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
