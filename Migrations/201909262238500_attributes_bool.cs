namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attributes_bool : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShownAttributes", "Guests", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "WebSite", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "Country", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "Email", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "PhoneNumber", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "ArrivalDetails", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ShownAttributes", "Notes", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShownAttributes", "Notes", c => c.String());
            AlterColumn("dbo.ShownAttributes", "ArrivalDetails", c => c.String());
            AlterColumn("dbo.ShownAttributes", "PhoneNumber", c => c.String());
            AlterColumn("dbo.ShownAttributes", "Email", c => c.String());
            AlterColumn("dbo.ShownAttributes", "Country", c => c.String());
            AlterColumn("dbo.ShownAttributes", "WebSite", c => c.String());
            AlterColumn("dbo.ShownAttributes", "Guests", c => c.Int(nullable: false));
        }
    }
}
