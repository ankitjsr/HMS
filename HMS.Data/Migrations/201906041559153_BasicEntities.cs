namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccmodationTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        NoOfRooms = c.Int(nullable: false),
                        FeePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccomodationType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationType_Id)
                .Index(t => t.AccomodationType_Id);
            
            CreateTable(
                "dbo.AccomodationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccomodationPackageId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccomodationPackages", t => t.AccomodationPackageId, cascadeDelete: true)
                .Index(t => t.AccomodationPackageId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Accomodation_Id = c.Int(),
                        AccomodationId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accomodations", t => t.Accomodation_Id)
                .ForeignKey("dbo.Accomodations", t => t.AccomodationId_Id)
                .Index(t => t.Accomodation_Id)
                .Index(t => t.AccomodationId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "AccomodationId_Id", "dbo.Accomodations");
            DropForeignKey("dbo.Bookings", "Accomodation_Id", "dbo.Accomodations");
            DropForeignKey("dbo.Accomodations", "AccomodationPackageId", "dbo.AccomodationPackages");
            DropForeignKey("dbo.AccomodationPackages", "AccomodationType_Id", "dbo.AccomodationTypes");
            DropIndex("dbo.Bookings", new[] { "AccomodationId_Id" });
            DropIndex("dbo.Bookings", new[] { "Accomodation_Id" });
            DropIndex("dbo.Accomodations", new[] { "AccomodationPackageId" });
            DropIndex("dbo.AccomodationPackages", new[] { "AccomodationType_Id" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Accomodations");
            DropTable("dbo.AccomodationTypes");
            DropTable("dbo.AccomodationPackages");
        }
    }
}
