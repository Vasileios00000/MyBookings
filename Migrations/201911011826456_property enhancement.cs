namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propertyenhancement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Bedrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Bathrooms", c => c.Int(nullable: false));
            AddColumn("dbo.Properties", "Sleeps", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Properties", "Sleeps");
            DropColumn("dbo.Properties", "Bathrooms");
            DropColumn("dbo.Properties", "Bedrooms");
        }
    }
}
