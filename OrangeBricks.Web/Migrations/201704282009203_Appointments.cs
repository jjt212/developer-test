namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Appointments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PropertyId = c.Int(nullable: false),
                        RequestingUserId = c.String(),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Comments = c.String(),
                        RequestedFor = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Appointments", new[] { "PropertyId" });
            DropTable("dbo.Appointments");
        }
    }
}
