using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public List<Ticket> Tickets { get; set; }
        public Order ()
        {
            Tickets = new List<Ticket>();
        }

    }
}