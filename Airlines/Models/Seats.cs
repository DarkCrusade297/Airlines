using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Seats
    {
        public int SeatID { get; set; }
        public int PlaneID { get; set; }
        public string SeatName { get; set; }
    }
}