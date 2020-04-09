using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class SearchModel
    {
        public bool Transfer { get; set; }
        public bool OneWay { get; set; }
        public int Person { get; set; }
        public IEnumerable<Flight> flightsTo { get; set; }
        public IEnumerable<Flight> flightsFrom { get; set; }
        public IEnumerable<TransferFlight> transferFlightsTo { get; set; }
        public IEnumerable<TransferFlight> transferFlightsFrom { get; set; }
    }
}