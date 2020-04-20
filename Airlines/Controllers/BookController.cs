using Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Airlines.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        AirlinesContext db = new AirlinesContext();
        public ActionResult r()
        {
            return View();
        }
        public ActionResult ChooseSeats(List<int> FlightID, int Person = 1)
        {
            if (FlightID == null)
            {
                return RedirectToAction("Search","Search");
            }
            var flights = new List<Flight>();
            foreach (var item in FlightID)
            {
                flights.Add(db.Flights.Find(item));
            }
            var flight = flights.First();
            var tickets = db.Tickets.Where(c => c.FlightID == flight.ID).ToList();
            var seats = new List<string>();
            foreach (var item in tickets)
            {
                var id = item.SeatID;
                var seat = db.Seats.Where(c => c.SeatID == id).First();
                seats.Add(seat.SeatName);
            }
            var bm = new BookModel() { Person = Person, Flights = flights, Seats = seats };
            return View(bm);
        }
        public ActionResult Confirmation(List<Customer> customers, List<int> flights, List<string> seats)
        {

            foreach (var item in customers)
            {
                db.Customers.Add(item);
            }
            Order order = new Order();
            order.UserId = User.Identity.GetUserId();
            db.Orders.Add(order);
            db.SaveChanges();
            return View();
        }


    }
}
