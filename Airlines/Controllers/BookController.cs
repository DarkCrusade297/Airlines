﻿using Airlines.Models;
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

        public ActionResult Index()
        {
            return View();

        }
        [HttpPost]
        public ActionResult FlightsSearch(int from, int to, DateTime dateTo, DateTime? dateFrom, bool oneway, bool transfer)
        {
            var CityFrom = db.Cities.Find(from);
            var CityTo = db.Cities.Find(to);
            IEnumerable<Flight> flightsFrom;
            SearchModel sm;
            DateTime endTime = dateTo.AddDays(1);
            var flightsTo = db.Flights.Where(a => a.ArrivalPlaceID == from && a.DeparturePlaceID == to && a.Arrival >= dateTo && a.Arrival < endTime).ToList();
            if (flightsTo.Count <= 0)
             {
                 return PartialView("NotFound");
             }
            if (transfer)
            {
                var trFlights = getFlights(from, to, dateTo);

            }
            
            if (!oneway)
            {
                flightsFrom = db.Flights.Where(a => a.ArrivalPlaceID == to && a.DeparturePlaceID == from && a.Arrival == dateFrom).ToList();
                if (flightsTo.Count <= 0)
                {
                    return PartialView("NotFound");
                }
                sm = new SearchModel { flightsTo = flightsTo, flightsFrom = flightsFrom, from = CityFrom, to = CityTo };
            }
            else
            sm = new SearchModel { flightsTo = flightsTo, flightsFrom = Enumerable.Empty<Flight>(), from = CityFrom, to = CityTo };
            return PartialView(sm);
        }
        public IEnumerable<TransferFlight> getFlights (int from, int to, DateTime dateTo)
        {
            List<TransferFlight> transferFlights = new List<TransferFlight>();
            DateTime endTime = dateTo.AddDays(1);
            var firstFlight = db.Flights.Where(f => f.ArrivalPlaceID == from && f.Arrival >= dateTo && f.Arrival < endTime && f.DeparturePlaceID != to).ToList();
            foreach (var item in firstFlight)
            {
                var endTime2 = item.Departure.AddHours(3);
                var endTime3 = item.Departure.AddHours(6);
                var secondFlight = db.Flights.Where(f => f.ArrivalPlaceID == item.DeparturePlaceID && f.Arrival >= endTime2 && f.Arrival <= endTime3 && f.DeparturePlaceID == to).ToList();
                foreach (var f in secondFlight)
                {
                    transferFlights.Add(new TransferFlight(item, f));
                }
            }
            foreach (var item in transferFlights)
            {
                item.FirstFlight.DeparturePlace = db.Cities.Find(item.FirstFlight.DeparturePlaceID);
                item.FirstFlight.ArrivalPlace = db.Cities.Find(item.FirstFlight.ArrivalPlaceID);
            }
            return transferFlights;
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
        public ActionResult ChooseSeats()
        {
            return View();
        }
    }
}
