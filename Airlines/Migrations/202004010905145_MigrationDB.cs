namespace Airlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Airport = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Flights", "ArrivalID", c => c.Int());
            AddColumn("dbo.Flights", "DepartureID", c => c.Int());
            AddColumn("dbo.Flights", "ArrivalPlace_ID", c => c.Int());
            AddColumn("dbo.Flights", "DeparturePlace_ID", c => c.Int());
            CreateIndex("dbo.Flights", "ArrivalPlace_ID");
            CreateIndex("dbo.Flights", "DeparturePlace_ID");
            AddForeignKey("dbo.Flights", "ArrivalPlace_ID", "dbo.Cities", "ID");
            AddForeignKey("dbo.Flights", "DeparturePlace_ID", "dbo.Cities", "ID");
            DropColumn("dbo.Flights", "ArrivalPlace");
            DropColumn("dbo.Flights", "DeparturePlace");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Flights", "DeparturePlace", c => c.String());
            AddColumn("dbo.Flights", "ArrivalPlace", c => c.String());
            DropForeignKey("dbo.Flights", "DeparturePlace_ID", "dbo.Cities");
            DropForeignKey("dbo.Flights", "ArrivalPlace_ID", "dbo.Cities");
            DropIndex("dbo.Flights", new[] { "DeparturePlace_ID" });
            DropIndex("dbo.Flights", new[] { "ArrivalPlace_ID" });
            DropColumn("dbo.Flights", "DeparturePlace_ID");
            DropColumn("dbo.Flights", "ArrivalPlace_ID");
            DropColumn("dbo.Flights", "DepartureID");
            DropColumn("dbo.Flights", "ArrivalID");
            DropTable("dbo.Cities");
        }
    }
}
