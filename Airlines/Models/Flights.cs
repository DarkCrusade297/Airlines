using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Flights
    {
        public int FlightID { get; set; }
        public int AirlineID { get; set; }
        public string PlaneFirm { get; set; }
        public int PlaneID { get; set; }
        public string ArrivalPlace { get; set; }
        public string DeparturePlace { get; set; }
    }
}