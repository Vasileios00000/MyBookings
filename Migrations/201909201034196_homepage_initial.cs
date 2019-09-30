namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homepage_initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "ArrivalDetails", c => c.String());
            AddColumn("dbo.Bookings", "Notes", c => c.String());
            DropColumn("dbo.Bookings", "FlightDetails_ArrivalDetails");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "FlightDetails_ArrivalDetails", c => c.String());
            DropColumn("dbo.Bookings", "Notes");
            DropColumn("dbo.Bookings", "ArrivalDetails");
        }
    }
}
