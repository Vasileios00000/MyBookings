namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbooking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "PropertyName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "PropertyName");
        }
    }
}
