using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class TransferFlight
    {
        public Flight FirstFlight { get; set; }
        public Flight SecondFlight { get; set; }
        public TimeSpan TravelTime { get; set; }
        public TransferFlight (Flight ff, Flight sf)
        {
            FirstFlight = ff;
            SecondFlight = sf;
            TravelTime = ff.TravelTime + sf.TravelTime + sf.Arrival.Subtract(ff.Departure);

        }

    }
}