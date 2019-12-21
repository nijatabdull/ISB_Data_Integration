namespace ISB_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Life : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ISB_Address_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressDetail = c.String(),
                        BuildingNumber = c.String(),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        FloorNumber = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        PostIndex = c.String(),
                        Settlement = c.String(),
                        StateCode = c.String(),
                        StateName = c.String(),
                        Street = c.String(),
                        TownCode = c.String(),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_AuthPerson_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_BankAccount_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AccountNo = c.String(),
                        BankId = c.Long(),
                        BankBranchId = c.Long(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        CurrencyPcode = c.String(),
                        CustomerNo = c.String(),
                        Iban = c.String(),
                        IntegrationInformation = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Bank_Life", t => t.BankId)
                .ForeignKey("dbo.ISB_BankBranch_Life", t => t.BankBranchId)
                .Index(t => t.BankId)
                .Index(t => t.BankBranchId);
            
            CreateTable(
                "dbo.ISB_Bank_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BankCode = c.String(),
                        BankName = c.String(),
                        CorrIban = c.String(),
                        CountryCode = c.String(),
                        SwiftNo = c.String(),
                        TaxId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_BankBranch_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BankCode = c.String(),
                        BankName = c.String(),
                        BranchCode = c.String(),
                        BranchName = c.String(),
                        InformerAccountCode = c.String(),
                        SwiftNo = c.String(),
                        TaxId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_Contact_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ContactTypePcode = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Gsm1 = c.String(),
                        Gsm2 = c.String(),
                        Tel1 = c.String(),
                        Tel2 = c.String(),
                        Web = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_ContractList_Life",
                c => new
                    {
                        ContractListId = c.Long(nullable: false, identity: true),
                        ActionTypePcode = c.String(),
                        AddendumEndDate = c.String(),
                        AddendumId = c.String(),
                        AddendumStartDate = c.String(),
                        AddendumTypePcode = c.String(),
                        AdministrativeFee = c.String(),
                        ContractId = c.String(),
                        ContractIdFull = c.String(),
                        Coverage = c.String(),
                        CoverageDiff = c.String(),
                        CurrencyPcode = c.String(),
                        EarnedPremium = c.String(),
                        EmployeerId = c.Long(),
                        EndDate = c.String(),
                        InsBankAccountId = c.Long(),
                        InsCompanyCode = c.String(),
                        IssueDate = c.String(),
                        LastNotificationDate = c.String(),
                        NumberOfInstallments = c.String(),
                        OriginalContractId = c.String(),
                        Premium = c.String(),
                        PremiumDiff = c.String(),
                        RejectReasonDesc = c.String(),
                        RejectReasonPcode = c.String(),
                        ReturnedPremiumFee = c.String(),
                        StartDate = c.String(),
                        StatusPcode = c.String(),
                        TermReasonOther = c.String(),
                        TermReasonPcode = c.String(),
                        TerminationDate = c.String(),
                        TypePcode = c.String(),
                        Uuid = c.String(),
                        RenewalId = c.String(),
                    })
                .PrimaryKey(t => t.ContractListId)
                .ForeignKey("dbo.ISB_Employeer_Ancestor_Life", t => t.EmployeerId)
                .ForeignKey("dbo.ISB_InsBankAccount_Life", t => t.InsBankAccountId)
                .Index(t => t.EmployeerId)
                .Index(t => t.InsBankAccountId);
            
            CreateTable(
                "dbo.ISB_EmployeeList_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressId = c.Long(),
                        ContactId = c.Long(),
                        PersonId = c.Long(),
                        ContractListId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Address_Life", t => t.AddressId)
                .ForeignKey("dbo.ISB_Contact_Life", t => t.ContactId)
                .ForeignKey("dbo.ISB_Person_Life", t => t.PersonId)
                .ForeignKey("dbo.ISB_ContractList_Life", t => t.ContractListId)
                .Index(t => t.AddressId)
                .Index(t => t.ContactId)
                .Index(t => t.PersonId)
                .Index(t => t.ContractListId);
            
            CreateTable(
                "dbo.ISB_EmploymentList_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ActionTypePcode = c.String(),
                        AdministrativeFee = c.String(),
                        Coverage = c.String(),
                        CoverageDiff = c.String(),
                        CurrencyPcode = c.String(),
                        EarnedPremium = c.String(),
                        EndDate = c.String(),
                        InsuranceRate = c.String(),
                        JobCategoryPcode = c.String(),
                        JobPositionId = c.String(),
                        JobPositionPcode = c.String(),
                        Premium = c.String(),
                        PremiumDiff = c.String(),
                        ReturnedPremiumFee = c.String(),
                        RiskCategoryPcode = c.String(),
                        Salary = c.String(),
                        StartDate = c.String(),
                        TerminationDate = c.String(),
                        EmployeeListId = c.Long(),
                        ISB_EmployeeList_Life_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_EmployeeList_Life", t => t.ISB_EmployeeList_Life_Id)
                .Index(t => t.ISB_EmployeeList_Life_Id);
            
            CreateTable(
                "dbo.ISB_Person_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_Employeer_Ancestor_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressId = c.Long(nullable: false),
                        AuthPersonId = c.Long(nullable: false),
                        ContactId = c.Long(nullable: false),
                        DelegatedAuthPersonId = c.Long(nullable: false),
                        EmployeerId = c.Long(nullable: false),
                        SignerPersonId = c.Long(nullable: false),
                        BankAccountId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Address_Life", t => t.AddressId)
                .ForeignKey("dbo.ISB_AuthPerson_Life", t => t.AuthPersonId)
                .ForeignKey("dbo.ISB_BankAccount_Life", t => t.BankAccountId)
                .ForeignKey("dbo.ISB_Contact_Life", t => t.ContactId)
                .ForeignKey("dbo.ISB_DelegatedAuthPerson_Life", t => t.DelegatedAuthPersonId)
                .ForeignKey("dbo.ISB_Employeer_Life", t => t.EmployeerId)
                .ForeignKey("dbo.ISB_SignerPerson_Life", t => t.SignerPersonId)
                .Index(t => t.AddressId)
                .Index(t => t.AuthPersonId)
                .Index(t => t.ContactId)
                .Index(t => t.DelegatedAuthPersonId)
                .Index(t => t.EmployeerId)
                .Index(t => t.SignerPersonId)
                .Index(t => t.BankAccountId);
            
            CreateTable(
                "dbo.ISB_DelegatedAuthPerson_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_Employeer_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_SignerPerson_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_InsBankAccount_Life",
                c => new
                    {
                        InsBankAccountId = c.Long(nullable: false, identity: true),
                        AccountNo = c.String(),
                        BankId = c.Long(),
                        BankBranchId = c.Long(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        CurrencyPcode = c.String(),
                        CustomerNo = c.String(),
                        Iban = c.String(),
                        IntegrationInformation = c.String(),
                    })
                .PrimaryKey(t => t.InsBankAccountId)
                .ForeignKey("dbo.ISB_Bank_Life", t => t.BankId)
                .ForeignKey("dbo.ISB_BankBranch_Life", t => t.BankBranchId)
                .Index(t => t.BankId)
                .Index(t => t.BankBranchId);
            
            CreateTable(
                "dbo.ISB_InstallmentList_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.String(),
                        CurrencyCode = c.String(),
                        InstallmentDate = c.String(),
                        InstallmentNumber = c.String(),
                        InvoiceId = c.Long(),
                        StatusPcode = c.String(),
                        ContractListId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Invoice_Life", t => t.InvoiceId)
                .ForeignKey("dbo.ISB_ContractList_Life", t => t.ContractListId, cascadeDelete: true)
                .Index(t => t.InvoiceId)
                .Index(t => t.ContractListId);
            
            CreateTable(
                "dbo.ISB_Invoice_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddendumId = c.String(),
                        Amount = c.String(),
                        ContractId = c.String(),
                        ContractIdFull = c.String(),
                        CreditorId = c.Long(),
                        CreditorAddressId = c.Long(),
                        CreditorContactId = c.Long(),
                        CurrencyCode = c.String(),
                        DebitorId = c.Long(),
                        DebitorAddressId = c.Long(),
                        DebitorContactId = c.Long(),
                        InsCompanyCode = c.String(),
                        InstallmentDate = c.String(),
                        InstallmentNumber = c.String(),
                        InvoiceDate = c.String(),
                        InvoiceId = c.String(),
                        InvoiceType = c.String(),
                        PaymentReceiverSubCode = c.String(),
                        RenewalId = c.String(),
                        TransactionId = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Creditor_Life", t => t.CreditorId)
                .ForeignKey("dbo.ISB_CreditorAddress_Life", t => t.CreditorAddressId)
                .ForeignKey("dbo.ISB_CreditorContact_Life", t => t.CreditorContactId)
                .ForeignKey("dbo.ISB_Debitor_Life", t => t.DebitorId)
                .ForeignKey("dbo.ISB_DebitorAddress_Life", t => t.DebitorAddressId)
                .ForeignKey("dbo.ISB_DebitorContact_Life", t => t.DebitorContactId)
                .Index(t => t.CreditorId)
                .Index(t => t.CreditorAddressId)
                .Index(t => t.CreditorContactId)
                .Index(t => t.DebitorId)
                .Index(t => t.DebitorAddressId)
                .Index(t => t.DebitorContactId);
            
            CreateTable(
                "dbo.ISB_Creditor_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_CreditorAddress_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressDetail = c.String(),
                        BuildingNumber = c.String(),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        FloorNumber = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        PostIndex = c.String(),
                        Settlement = c.String(),
                        StateCode = c.String(),
                        StateName = c.String(),
                        Street = c.String(),
                        TownCode = c.String(),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_CreditorContact_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ContactTypePcode = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Gsm1 = c.String(),
                        Gsm2 = c.String(),
                        Tel1 = c.String(),
                        Tel2 = c.String(),
                        Web = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_Debitor_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DateOfBirth = c.String(),
                        DateOfDeath = c.String(),
                        EconomicActivityPcode = c.String(),
                        EducationStatusPcode = c.String(),
                        FatherName = c.String(),
                        GenderPcode = c.String(),
                        Idn = c.String(),
                        MaritalStatusPcode = c.String(),
                        MiddleName = c.String(),
                        MotherName = c.String(),
                        Name = c.String(),
                        NationalityPcode = c.String(),
                        Passport = c.String(),
                        PersonTypePcode = c.String(),
                        PlaceOfBirth = c.String(),
                        Position = c.String(),
                        Surname = c.String(),
                        TaxId = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_DebitorAddress_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AddressDetail = c.String(),
                        BuildingNumber = c.String(),
                        CityCode = c.String(),
                        CityName = c.String(),
                        CountryCode = c.String(),
                        CountryName = c.String(),
                        FloorNumber = c.String(),
                        Latitude = c.String(),
                        Longitude = c.String(),
                        PostIndex = c.String(),
                        Settlement = c.String(),
                        StateCode = c.String(),
                        StateName = c.String(),
                        Street = c.String(),
                        TownCode = c.String(),
                        TownName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_DebitorContact_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ContactTypePcode = c.String(),
                        Description = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Gsm1 = c.String(),
                        Gsm2 = c.String(),
                        Tel1 = c.String(),
                        Tel2 = c.String(),
                        Web = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ISB_PaymentList_Life",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Amount = c.String(),
                        CurrencyCode = c.String(),
                        InsCompanyCode = c.String(),
                        InvoiceId = c.String(),
                        PaymentDate = c.String(),
                        PaymentReceiverSubCode = c.String(),
                        ReceiptNumber = c.String(),
                        ISB_Invoice_Life_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ISB_Invoice_Life", t => t.ISB_Invoice_Life_Id)
                .Index(t => t.ISB_Invoice_Life_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ISB_InstallmentList_Life", "ContractListId", "dbo.ISB_ContractList_Life");
            DropForeignKey("dbo.ISB_InstallmentList_Life", "InvoiceId", "dbo.ISB_Invoice_Life");
            DropForeignKey("dbo.ISB_PaymentList_Life", "ISB_Invoice_Life_Id", "dbo.ISB_Invoice_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "DebitorContactId", "dbo.ISB_DebitorContact_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "DebitorAddressId", "dbo.ISB_DebitorAddress_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "DebitorId", "dbo.ISB_Debitor_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "CreditorContactId", "dbo.ISB_CreditorContact_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "CreditorAddressId", "dbo.ISB_CreditorAddress_Life");
            DropForeignKey("dbo.ISB_Invoice_Life", "CreditorId", "dbo.ISB_Creditor_Life");
            DropForeignKey("dbo.ISB_ContractList_Life", "InsBankAccountId", "dbo.ISB_InsBankAccount_Life");
            DropForeignKey("dbo.ISB_InsBankAccount_Life", "BankBranchId", "dbo.ISB_BankBranch_Life");
            DropForeignKey("dbo.ISB_InsBankAccount_Life", "BankId", "dbo.ISB_Bank_Life");
            DropForeignKey("dbo.ISB_ContractList_Life", "EmployeerId", "dbo.ISB_Employeer_Ancestor_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "SignerPersonId", "dbo.ISB_SignerPerson_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "EmployeerId", "dbo.ISB_Employeer_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "DelegatedAuthPersonId", "dbo.ISB_DelegatedAuthPerson_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "ContactId", "dbo.ISB_Contact_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "BankAccountId", "dbo.ISB_BankAccount_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "AuthPersonId", "dbo.ISB_AuthPerson_Life");
            DropForeignKey("dbo.ISB_Employeer_Ancestor_Life", "AddressId", "dbo.ISB_Address_Life");
            DropForeignKey("dbo.ISB_EmployeeList_Life", "ContractListId", "dbo.ISB_ContractList_Life");
            DropForeignKey("dbo.ISB_EmployeeList_Life", "PersonId", "dbo.ISB_Person_Life");
            DropForeignKey("dbo.ISB_EmploymentList_Life", "ISB_EmployeeList_Life_Id", "dbo.ISB_EmployeeList_Life");
            DropForeignKey("dbo.ISB_EmployeeList_Life", "ContactId", "dbo.ISB_Contact_Life");
            DropForeignKey("dbo.ISB_EmployeeList_Life", "AddressId", "dbo.ISB_Address_Life");
            DropForeignKey("dbo.ISB_BankAccount_Life", "BankBranchId", "dbo.ISB_BankBranch_Life");
            DropForeignKey("dbo.ISB_BankAccount_Life", "BankId", "dbo.ISB_Bank_Life");
            DropIndex("dbo.ISB_PaymentList_Life", new[] { "ISB_Invoice_Life_Id" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "DebitorContactId" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "DebitorAddressId" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "DebitorId" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "CreditorContactId" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "CreditorAddressId" });
            DropIndex("dbo.ISB_Invoice_Life", new[] { "CreditorId" });
            DropIndex("dbo.ISB_InstallmentList_Life", new[] { "ContractListId" });
            DropIndex("dbo.ISB_InstallmentList_Life", new[] { "InvoiceId" });
            DropIndex("dbo.ISB_InsBankAccount_Life", new[] { "BankBranchId" });
            DropIndex("dbo.ISB_InsBankAccount_Life", new[] { "BankId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "BankAccountId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "SignerPersonId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "EmployeerId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "DelegatedAuthPersonId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "ContactId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "AuthPersonId" });
            DropIndex("dbo.ISB_Employeer_Ancestor_Life", new[] { "AddressId" });
            DropIndex("dbo.ISB_EmploymentList_Life", new[] { "ISB_EmployeeList_Life_Id" });
            DropIndex("dbo.ISB_EmployeeList_Life", new[] { "ContractListId" });
            DropIndex("dbo.ISB_EmployeeList_Life", new[] { "PersonId" });
            DropIndex("dbo.ISB_EmployeeList_Life", new[] { "ContactId" });
            DropIndex("dbo.ISB_EmployeeList_Life", new[] { "AddressId" });
            DropIndex("dbo.ISB_ContractList_Life", new[] { "InsBankAccountId" });
            DropIndex("dbo.ISB_ContractList_Life", new[] { "EmployeerId" });
            DropIndex("dbo.ISB_BankAccount_Life", new[] { "BankBranchId" });
            DropIndex("dbo.ISB_BankAccount_Life", new[] { "BankId" });
            DropTable("dbo.ISB_PaymentList_Life");
            DropTable("dbo.ISB_DebitorContact_Life");
            DropTable("dbo.ISB_DebitorAddress_Life");
            DropTable("dbo.ISB_Debitor_Life");
            DropTable("dbo.ISB_CreditorContact_Life");
            DropTable("dbo.ISB_CreditorAddress_Life");
            DropTable("dbo.ISB_Creditor_Life");
            DropTable("dbo.ISB_Invoice_Life");
            DropTable("dbo.ISB_InstallmentList_Life");
            DropTable("dbo.ISB_InsBankAccount_Life");
            DropTable("dbo.ISB_SignerPerson_Life");
            DropTable("dbo.ISB_Employeer_Life");
            DropTable("dbo.ISB_DelegatedAuthPerson_Life");
            DropTable("dbo.ISB_Employeer_Ancestor_Life");
            DropTable("dbo.ISB_Person_Life");
            DropTable("dbo.ISB_EmploymentList_Life");
            DropTable("dbo.ISB_EmployeeList_Life");
            DropTable("dbo.ISB_ContractList_Life");
            DropTable("dbo.ISB_Contact_Life");
            DropTable("dbo.ISB_BankBranch_Life");
            DropTable("dbo.ISB_Bank_Life");
            DropTable("dbo.ISB_BankAccount_Life");
            DropTable("dbo.ISB_AuthPerson_Life");
            DropTable("dbo.ISB_Address_Life");
        }
    }
}
