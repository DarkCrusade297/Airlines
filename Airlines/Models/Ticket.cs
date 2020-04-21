using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Airlines.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int? CustomerID { get; set; }
        public Customer Customer { get; set; }
        public int? FlightID { get; set; }
        public Flight Flight { get; set; }
        public int? SeatID { get; set; }
        public Seat Seat{ get; set; }
        public int? OrderID { get; set; }
        public Order Order { get; set; }
        public Ticket()
        {

        }
        public Ticket(int CusID, int FlID, int? SeatID, int OrderID)
        {
            CustomerID = CusID;
            FlightID = FlID;
            this.SeatID = SeatID;
            this.OrderID = OrderID;
    }
        public Ticket(int CusID, int FlID, int OrderID)
        {
            CustomerID = CusID;
            FlightID = FlID;
            this.OrderID = OrderID;
        }
    }

}