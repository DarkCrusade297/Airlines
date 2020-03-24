using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Airlines.Models
{
    public class AirlinesContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Class1> Class1s { get; set; }

        public AirlinesContext() : base("AirlinesContext") { }

    }
    public class AirlinesDbInitializer: DropCreateDatabaseAlways<AirlinesContext>
    {
        protected override void Seed (AirlinesContext db)
        {
            db.Customers.Add(new Customer { Name = "Artur", Surname = "Platov", Patronymic = "Sergeevich" });
            db.Customers.Add(new Customer { Name = "Sasha", Surname = "Platova", Patronymic = "Sergeevna" });
            base.Seed(db);
        }
    }
}