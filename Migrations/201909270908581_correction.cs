namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AttributesId", c => c.String());
            DropColumn("dbo.AspNetUsers", "AttibutesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "AttibutesId", c => c.String());
            DropColumn("dbo.AspNetUsers", "AttributesId");
        }
    }
}
