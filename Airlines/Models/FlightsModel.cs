using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Airlines.Models
{
    public class FlightsModel
    {
        public IEnumerable<Flight> Flights { get; set; }
    }
}