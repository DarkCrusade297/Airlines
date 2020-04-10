using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class BookModel
    {
        public int Person { get; set; }
        public IEnumerable<Flight> Flights { get; set; }

    }
}