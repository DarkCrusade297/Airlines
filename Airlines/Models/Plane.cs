using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Plane
    {
        public int PlaneID { get; set; }
        public string PlaneModel { get; set; }
        public int EconomSeats { get; set; }
        public int BuisnessSeats { get; set; }
    }
}