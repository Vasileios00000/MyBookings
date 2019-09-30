namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class website : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "Guests", c => c.Int(nullable: false));
            AddColumn("dbo.Bookings", "WebSite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "WebSite");
            DropColumn("dbo.Bookings", "Guests");
        }
    }
}
