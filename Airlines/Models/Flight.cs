using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string Airline { get; set; }
        public int? PlaneID { get; set; }
        public Plane Plane { get; set; }
        public string ArrivalPlace { get; set; }
        public string DeparturePlace { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}