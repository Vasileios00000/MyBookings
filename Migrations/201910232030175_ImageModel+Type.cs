namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageModelType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Type");
        }
    }
}
