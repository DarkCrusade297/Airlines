using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int CustomerID { get; set; }
        public string Gate { get; set; }
    }
}