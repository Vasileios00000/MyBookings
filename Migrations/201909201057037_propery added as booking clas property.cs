namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class properyaddedasbookingclasproperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bookings", "PropertyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bookings", "PropertyName", c => c.String());
        }
    }
}
