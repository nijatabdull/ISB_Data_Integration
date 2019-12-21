namespace ISB_Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompletionStatus_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DamageType_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverStatus_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DriverType_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fullname = c.String(),
                        StructureName = c.String(),
                        RankName = c.String(),
                        PositionName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Forma4List",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DocNumber = c.String(),
                        ActionDate = c.String(),
                        IncidentStatusId = c.String(maxLength: 128),
                        CompletionStatusId = c.String(maxLength: 128),
                        IncidentRegionId = c.String(maxLength: 128),
                        ActionLocation = c.String(),
                        EmployeeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CompletionStatus_Forma4", t => t.CompletionStatusId)
                .ForeignKey("dbo.Employee_Forma4", t => t.EmployeeId)
                .ForeignKey("dbo.IncidentRegion_Forma4", t => t.IncidentRegionId)
                .ForeignKey("dbo.IncidentStatus_Forma4", t => t.IncidentStatusId)
                .Index(t => t.IncidentStatusId)
                .Index(t => t.CompletionStatusId)
                .Index(t => t.IncidentRegionId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.IncidentRegion_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IncidentStatus_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IncidentTypeList_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Forma4ListId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forma4List", t => t.Forma4ListId)
                .Index(t => t.Forma4ListId);
            
            CreateTable(
                "dbo.PersonWrapperList_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonId = c.String(maxLength: 128),
                        Foreign = c.Boolean(nullable: false),
                        DiriverLicenseExists = c.Boolean(nullable: false),
                        DriverTypeId = c.String(maxLength: 128),
                        DriverStatusId = c.String(maxLength: 128),
                        DamageTypeId = c.String(maxLength: 128),
                        PersonStatuseId = c.String(maxLength: 128),
                        ParticipanTypeId = c.String(maxLength: 128),
                        ProSeriesNumber = c.String(),
                        DlSeriesNumber = c.String(),
                        VehicleNumber = c.String(),
                        Forma4ListId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DamageType_Forma4", t => t.DamageTypeId)
                .ForeignKey("dbo.DriverStatus_Forma4", t => t.DriverStatusId)
                .ForeignKey("dbo.DriverType_Forma4", t => t.DriverTypeId)
                .ForeignKey("dbo.ParticipanType_Forma4", t => t.ParticipanTypeId)
                .ForeignKey("dbo.Person_Forma4", t => t.PersonId)
                .ForeignKey("dbo.PersonStatus_Forma4", t => t.PersonStatuseId)
                .ForeignKey("dbo.Forma4List", t => t.Forma4ListId)
                .Index(t => t.PersonId)
                .Index(t => t.DriverTypeId)
                .Index(t => t.DriverStatusId)
                .Index(t => t.DamageTypeId)
                .Index(t => t.PersonStatuseId)
                .Index(t => t.ParticipanTypeId)
                .Index(t => t.Forma4ListId);
            
            CreateTable(
                "dbo.ParticipanType_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Patronymic = c.String(),
                        BirthDate = c.String(),
                        MobileNumber = c.String(),
                        Email = c.String(),
                        PersonTypeId = c.String(maxLength: 128),
                        IdNumber = c.String(),
                        Pin = c.String(),
                        TaxNumber = c.String(),
                        PassportNo = c.String(),
                        RegAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonType_Forma4", t => t.PersonTypeId)
                .Index(t => t.PersonTypeId);
            
            CreateTable(
                "dbo.PersonType_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonStatus_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleWrapperList_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        VehicleId = c.String(maxLength: 128),
                        TechnicalFailureId = c.String(maxLength: 128),
                        Forma4ListId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TechnicalFailure_Forma4", t => t.TechnicalFailureId)
                .ForeignKey("dbo.Vehicle_Forma4", t => t.VehicleId)
                .ForeignKey("dbo.Forma4List", t => t.Forma4ListId)
                .Index(t => t.VehicleId)
                .Index(t => t.TechnicalFailureId)
                .Index(t => t.Forma4ListId);
            
            CreateTable(
                "dbo.TechnicalFailure_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        PersonId = c.String(maxLength: 128),
                        CertNumber = c.String(),
                        CarNumber = c.String(),
                        Marka = c.String(),
                        VehicleTypeId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person_Forma4", t => t.PersonId)
                .ForeignKey("dbo.VehicleType_Forma4", t => t.VehicleTypeId)
                .Index(t => t.PersonId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleType_Forma4",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleWrapperList_Forma4", "Forma4ListId", "dbo.Forma4List");
            DropForeignKey("dbo.VehicleWrapperList_Forma4", "VehicleId", "dbo.Vehicle_Forma4");
            DropForeignKey("dbo.Vehicle_Forma4", "VehicleTypeId", "dbo.VehicleType_Forma4");
            DropForeignKey("dbo.Vehicle_Forma4", "PersonId", "dbo.Person_Forma4");
            DropForeignKey("dbo.VehicleWrapperList_Forma4", "TechnicalFailureId", "dbo.TechnicalFailure_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "Forma4ListId", "dbo.Forma4List");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "PersonStatuseId", "dbo.PersonStatus_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "PersonId", "dbo.Person_Forma4");
            DropForeignKey("dbo.Person_Forma4", "PersonTypeId", "dbo.PersonType_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "ParticipanTypeId", "dbo.ParticipanType_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "DriverTypeId", "dbo.DriverType_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "DriverStatusId", "dbo.DriverStatus_Forma4");
            DropForeignKey("dbo.PersonWrapperList_Forma4", "DamageTypeId", "dbo.DamageType_Forma4");
            DropForeignKey("dbo.IncidentTypeList_Forma4", "Forma4ListId", "dbo.Forma4List");
            DropForeignKey("dbo.Forma4List", "IncidentStatusId", "dbo.IncidentStatus_Forma4");
            DropForeignKey("dbo.Forma4List", "IncidentRegionId", "dbo.IncidentRegion_Forma4");
            DropForeignKey("dbo.Forma4List", "EmployeeId", "dbo.Employee_Forma4");
            DropForeignKey("dbo.Forma4List", "CompletionStatusId", "dbo.CompletionStatus_Forma4");
            DropIndex("dbo.Vehicle_Forma4", new[] { "VehicleTypeId" });
            DropIndex("dbo.Vehicle_Forma4", new[] { "PersonId" });
            DropIndex("dbo.VehicleWrapperList_Forma4", new[] { "Forma4ListId" });
            DropIndex("dbo.VehicleWrapperList_Forma4", new[] { "TechnicalFailureId" });
            DropIndex("dbo.VehicleWrapperList_Forma4", new[] { "VehicleId" });
            DropIndex("dbo.Person_Forma4", new[] { "PersonTypeId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "Forma4ListId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "ParticipanTypeId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "PersonStatuseId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "DamageTypeId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "DriverStatusId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "DriverTypeId" });
            DropIndex("dbo.PersonWrapperList_Forma4", new[] { "PersonId" });
            DropIndex("dbo.IncidentTypeList_Forma4", new[] { "Forma4ListId" });
            DropIndex("dbo.Forma4List", new[] { "EmployeeId" });
            DropIndex("dbo.Forma4List", new[] { "IncidentRegionId" });
            DropIndex("dbo.Forma4List", new[] { "CompletionStatusId" });
            DropIndex("dbo.Forma4List", new[] { "IncidentStatusId" });
            DropTable("dbo.VehicleType_Forma4");
            DropTable("dbo.Vehicle_Forma4");
            DropTable("dbo.TechnicalFailure_Forma4");
            DropTable("dbo.VehicleWrapperList_Forma4");
            DropTable("dbo.PersonStatus_Forma4");
            DropTable("dbo.PersonType_Forma4");
            DropTable("dbo.Person_Forma4");
            DropTable("dbo.ParticipanType_Forma4");
            DropTable("dbo.PersonWrapperList_Forma4");
            DropTable("dbo.IncidentTypeList_Forma4");
            DropTable("dbo.IncidentStatus_Forma4");
            DropTable("dbo.IncidentRegion_Forma4");
            DropTable("dbo.Forma4List");
            DropTable("dbo.Employee_Forma4");
            DropTable("dbo.DriverType_Forma4");
            DropTable("dbo.DriverStatus_Forma4");
            DropTable("dbo.DamageType_Forma4");
            DropTable("dbo.CompletionStatus_Forma4");
        }
    }
}
