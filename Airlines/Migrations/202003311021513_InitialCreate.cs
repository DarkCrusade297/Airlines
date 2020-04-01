namespace Airlines.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        PassportNumber = c.String(),
                        PassportDate = c.DateTime(nullable: false),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Airline = c.String(),
                        PlaneID = c.Int(),
                        ArrivalPlace = c.String(),
                        DeparturePlace = c.String(),
                        Arrival = c.DateTime(nullable: false),
                        Departure = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Planes", t => t.PlaneID)
                .Index(t => t.PlaneID);
            
            CreateTable(
                "dbo.Planes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Firm = c.String(),
                        Model = c.String(),
                        EconomSeats = c.Int(nullable: false),
                        BuisnessSeats = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Seats",
                c => new
                    {
                        SeatID = c.Int(nullable: false, identity: true),
                        PlaneID = c.Int(),
                        SeatName = c.String(),
                    })
                .PrimaryKey(t => t.SeatID)
                .ForeignKey("dbo.Planes", t => t.PlaneID)
                .Index(t => t.PlaneID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        FlightID = c.Int(),
                        Gate = c.String(),
                        BoardingTime = c.DateTime(nullable: false),
                        SeatID = c.Int(),
                        AriivalTime = c.DateTime(nullable: false),
                        BoardingPriority = c.Int(nullable: false),
                        DeapartureTime = c.DateTime(nullable: false),
                        DepartureTerminal = c.String(),
                    })
                .PrimaryKey(t => t.TicketID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .ForeignKey("dbo.Flights", t => t.FlightID)
                .ForeignKey("dbo.Seats", t => t.SeatID)
                .Index(t => t.CustomerID)
                .Index(t => t.FlightID)
                .Index(t => t.SeatID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "SeatID", "dbo.Seats");
            DropForeignKey("dbo.Tickets", "FlightID", "dbo.Flights");
            DropForeignKey("dbo.Tickets", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Seats", "PlaneID", "dbo.Planes");
            DropForeignKey("dbo.Flights", "PlaneID", "dbo.Planes");
            DropIndex("dbo.Tickets", new[] { "SeatID" });
            DropIndex("dbo.Tickets", new[] { "FlightID" });
            DropIndex("dbo.Tickets", new[] { "CustomerID" });
            DropIndex("dbo.Seats", new[] { "PlaneID" });
            DropIndex("dbo.Flights", new[] { "PlaneID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Seats");
            DropTable("dbo.Planes");
            DropTable("dbo.Flights");
            DropTable("dbo.Customers");
        }
    }
}
