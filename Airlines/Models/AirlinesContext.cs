using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Airlines.Models
{
    public class AirlinesContext: DbContext { 
         public AirlinesContext()
    { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}