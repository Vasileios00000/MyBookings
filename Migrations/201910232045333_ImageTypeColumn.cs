namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageTypeColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageType", c => c.String());
            DropColumn("dbo.Images", "Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Type", c => c.String());
            DropColumn("dbo.Images", "ImageType");
        }
    }
}
