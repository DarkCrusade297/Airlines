using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int? FlightID { get; set; }
        public Flight Flight { get; set; }
        public string Gate { get; set; }
        public DateTime BoardingTime { get; set; }
        public int? SeatID { get; set; }
        public Seat Seat{ get; set; }
        public DateTime AriivalTime { get; set; }
        public int BoardingPriority { get; set; }
        public DateTime DeapartureTime { get; set; }
        public string DepartureTerminal { get; set; }
    }
}