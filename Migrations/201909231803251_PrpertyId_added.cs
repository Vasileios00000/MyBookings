namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrpertyId_added : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.Bookings", new[] { "Property_Id" });
            RenameColumn(table: "dbo.Bookings", name: "Property_Id", newName: "PropertyId");
            AlterColumn("dbo.Bookings", "PropertyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "PropertyId");
            AddForeignKey("dbo.Bookings", "PropertyId", "dbo.Properties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "PropertyId", "dbo.Properties");
            DropIndex("dbo.Bookings", new[] { "PropertyId" });
            AlterColumn("dbo.Bookings", "PropertyId", c => c.Int());
            RenameColumn(table: "dbo.Bookings", name: "PropertyId", newName: "Property_Id");
            CreateIndex("dbo.Bookings", "Property_Id");
            AddForeignKey("dbo.Bookings", "Property_Id", "dbo.Properties", "Id");
        }
    }
}
