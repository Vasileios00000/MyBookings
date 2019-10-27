namespace MyBookings.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropCountries : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Countries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                    })
                .PrimaryKey(t => t.CountryId);
            
        }
    }
}
