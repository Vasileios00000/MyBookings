namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class surnameToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SurName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "SurName");
        }
    }
}
