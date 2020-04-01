using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class SearchModel
    {
        public City from { get; set; }
        public City to { get; set; }
        public IEnumerable<Flight> flightsTo { get; set; }
        public IEnumerable<Flight> flightsFrom { get; set; }
        public IEnumerable<Flight> flightsBetween { get; set; }
    }
}