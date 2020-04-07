using Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
        public ActionResult Ticket()
        {
            return View();

        }
        [HttpPost]
        public ActionResult FlightsSearch(int from, int to, DateTime dateTo, bool oneway, bool transfer, DateTime? dateFrom)
        {
            DateTime endTime2 = new DateTime();
            if (dateFrom != null)
            {
                endTime2 = Convert.ToDateTime(dateFrom);
            }
            var CityFrom = db.Cities.Find(from);
            var CityTo = db.Cities.Find(to);
            var players = db.Flights.Include(p => p.Plane).ToList();
            IEnumerable<Flight> flightsFrom = new List<Flight>(); ;
            IEnumerable<TransferFlight> transferflightsTo = new List<TransferFlight>();
            IEnumerable<TransferFlight> transferflightsFrom = new List<TransferFlight>();
            SearchModel sm;
            DateTime endTime = dateTo.AddDays(1);
            var flightsTo = db.Flights.Where(a => a.ArrivalPlaceID == from && a.DeparturePlaceID == to && a.Arrival >= dateTo && a.Arrival < endTime).ToList();
            if (oneway)
            {
                if (transfer)
                {
                    transferflightsTo = getFlights(from, to, dateTo).ToList();
                }
                if (flightsTo.Count <= 0 && transferflightsTo.Count() <= 0)
                {
                    return PartialView("NotFound");
                }
            }
            else
            {
                DateTime time = endTime2.AddDays(1);
                flightsFrom = db.Flights.Where(a => a.ArrivalPlaceID == to && a.DeparturePlaceID == from && a.Arrival >= dateFrom && a.Arrival < time).ToList();
                if (transfer)
                {
                    transferflightsTo = getFlights(from, to, dateTo).ToList();
                    transferflightsFrom = getFlights(to, from, endTime2).ToList();
                }
                if (flightsTo.Count <= 0 && transferflightsTo.Count() <= 0 && flightsFrom.Count() <= 0 && transferflightsFrom.Count() <= 0)
                {
                    return PartialView("NotFound");
                }


            }
            sm = new SearchModel { flightsTo = flightsTo, flightsFrom = flightsFrom, from = CityFrom, to = CityTo, transferFlightsTo = transferflightsTo, transferFlightsFrom = transferflightsFrom, Transfer = transfer, OneWay = oneway};
           // sm = new SearchModel { flightsTo = flightsTo, flightsFrom = Enumerable.Empty<Flight>(),  transferFlightsTo = transferflightsTo, from = CityFrom, to = CityTo, Transfer = transfer, OneWay = oneway };
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
                var endTime3 = item.Departure.AddHours(10);
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
