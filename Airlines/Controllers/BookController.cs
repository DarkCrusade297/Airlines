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
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChooseSeats(List<int> FlightID, int Person)
        {
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
            var bm = new BookModel() { Person=Person, Flights = flights, Seats = seats };
            return View(bm);
        }
        public ActionResult Confirmation(List<Customer> customers, BookModel bm)
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


        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
