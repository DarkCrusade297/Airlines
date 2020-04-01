using Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airlines.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        AirlinesContext db = new AirlinesContext();

        public ActionResult Index(int? team, string position)
        {
            return View();

        }
        [HttpPost]
        public ActionResult FlightsSearch(string from)
        {
            var allflights = db.Flights.Where(a => a.ArrivalPlace.Contains(from)).ToList();
            if (allflights.Count <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(allflights);
        }
        public ActionResult Search (string from, string to)
        {
            IQueryable<Flight> flights = from f in db.Flights select f;

            if (!String.IsNullOrEmpty(from))
            {
               flights = flights.Where(f => f.ArrivalPlace == from);
            }
            FlightsModel fm = new FlightsModel { Flights = flights.ToList() };
            return View(fm);
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
