namespace VidlyOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(nullable: false, maxLength: 24),
                        Model = c.String(nullable: false, maxLength: 24),
                        CarBodyId = c.Int(nullable: false),
                        Fuel = c.String(nullable: false, maxLength: 10),
                        PricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarBodies", t => t.CarBodyId, cascadeDelete: true)
                .Index(t => t.CarBodyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "CarBodyId", "dbo.CarBodies");
            DropIndex("dbo.Cars", new[] { "CarBodyId" });
            DropTable("dbo.Cars");
        }
    }
}
