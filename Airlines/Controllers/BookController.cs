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
        public ActionResult FlightsSearch(int from, int to, DateTime dateTo, DateTime? dateFrom, bool oneway)
        {
            var CityFrom = db.Cities.Find(from);
            var CityTo = db.Cities.Find(to);
            IEnumerable<Flight> flightsFrom;
            SearchModel sm;
            DateTime endTime = dateTo.AddDays(1);
            var flightsTo = db.Flights.Where(a => a.ArrivalID == from && a.DepartureID == to && a.Arrival >= dateTo && a.Arrival < endTime).ToList();
            if (flightsTo.Count <= 0)
            {
                return HttpNotFound();
            }
            if (!oneway)
            {
                flightsFrom = db.Flights.Where(a => a.ArrivalID == to && a.DepartureID == from && a.Arrival == dateFrom).ToList();
                if (flightsTo.Count <= 0)
                {
                    return HttpNotFound();
                }
                sm = new SearchModel { flightsTo = flightsTo, flightsFrom = flightsFrom, from = CityFrom, to = CityTo };
            }
            else
            sm = new SearchModel { flightsTo = flightsTo, from = CityFrom, to = CityTo };
            return PartialView(sm);
        }
        public ActionResult Search ()
        {
            ViewBag.Cities = new SelectList(db.Cities, "ID", "Name");
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
