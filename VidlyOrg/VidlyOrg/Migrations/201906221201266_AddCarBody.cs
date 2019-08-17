namespace VidlyOrg.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCarBody : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarBodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CarBodies");
        }
    }
}
