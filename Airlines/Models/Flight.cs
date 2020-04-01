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
        public int? ArrivalID { get; set; }
        public City ArrivalPlace { get; set; }
        public int? DepartureID { get; set; }
        public City DeparturePlace { get; set; }
        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }
    }
}