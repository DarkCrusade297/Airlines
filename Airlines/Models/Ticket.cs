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
        public int FlightID { get; set; }
        public string Gate { get; set; }
        public DateTime BoardingTime { get; set; }
        public string BoardingTerminal { get; set; }
        public int SeatID { get; set; }
        public DateTime AriivalTime { get; set; }
        public int BoardingPriority { get; set; }
        public DateTime DeapartureTime { get; set; }
        public string DepartureTerminal { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}