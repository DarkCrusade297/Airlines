using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Airport { get; set; }
        public DateTime TimeZone { get; set; }
    }
}