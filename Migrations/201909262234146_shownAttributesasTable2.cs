namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shownAttributesasTable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AttibutesId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AttibutesId");
        }
    }
}
