using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Plane
    {
        public int ID { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public int EconomSeats { get; set; }
        public int BuisnessSeats { get; set; }
    }
}