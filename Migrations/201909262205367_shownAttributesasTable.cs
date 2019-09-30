namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shownAttributesasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShownAttributes",
                c => new
                    {
                        ShownAttributesId = c.String(nullable: false, maxLength: 128),
                        Show_Id = c.Boolean(nullable: false),
                        Property = c.Boolean(nullable: false),
                        ClientName = c.Boolean(nullable: false),
                        CheckIn = c.Boolean(nullable: false),
                        CheckOut = c.Boolean(nullable: false),
                        Guests = c.Int(nullable: false),
                        WebSite = c.String(),
                        Country = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        ArrivalDetails = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.ShownAttributesId)
                .ForeignKey("dbo.AspNetUsers", t => t.ShownAttributesId)
                .Index(t => t.ShownAttributesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShownAttributes", "ShownAttributesId", "dbo.AspNetUsers");
            DropIndex("dbo.ShownAttributes", new[] { "ShownAttributesId" });
            DropTable("dbo.ShownAttributes");
        }
    }
}
