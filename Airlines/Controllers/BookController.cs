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
        public ActionResult Confirmation(List<Customer> customers, List<int> flights, List<string> seats, int person)
        {
            var tickets = db.Tickets.Where(c => c.FlightID == flights.FirstOrDefault()).ToList();
            var seatsNames = new List<string>();
            foreach (var item in tickets)
            {
                var id = item.SeatID;
                var seat = db.Seats.Where(c => c.SeatID == id).First();
                seatsNames.Add(seat.SeatName);
            }
            bool check=false;
            foreach (var item in seats)
            {
                foreach (var i in seatsNames)
                {
                    if (item == i)
                    {
                        check = true;
                    }
                }
            }
            if (check)
            {
                var fl = new List<Flight>();
                foreach (var item in flights)
                {
                    fl.Add(db.Flights.Find(item));
                }
                var bm = new BookModel() { Person = person, Flights = fl, Seats = seatsNames };
                return View("ChooseSeats", bm);
            }
            Order order = new Order();
            order.UserId = User.Identity.GetUserId();
            order.OrderTime = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var item in customers)
            {
                db.Customers.Add(item);
                db.SaveChanges();
            }
            var plane = db.Flights.Find(flights.First()).PlaneID;
            var s = db.Seats.Where(c => c.PlaneID == plane);
            var seatsID = new List<int>();
            foreach (var item in seats)
            {
                seatsID.Add(db.Seats.Where(c => c.PlaneID == plane && c.SeatName == item).First().SeatID);
            }
            for (int i = 0; i<flights.Count;i++)
            {
                for (int j = 0; j< customers.Count;j++)
                {
                    if (i==0)
                    {
                        db.Tickets.Add(new Ticket(customers[j].CustomerID, flights.ElementAt(i), seatsID.ElementAt(j), order.ID));
                    }
                    else
                    db.Tickets.Add(new Ticket(customers[j].CustomerID, flights.ElementAt(i), order.ID));
                }
            }
            db.SaveChanges();
            return View();
        }


    }
}
