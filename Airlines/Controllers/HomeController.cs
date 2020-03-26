using Airlines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Airlines.Controllers
{
    public class HomeController : Controller
    {
        AirlinesContext db = new AirlinesContext();
        public ActionResult Index()
        {
            var customers = db.Customers;
            ViewBag.Customers = customers;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult View2()
        {
            return View();
        }
        [Authorize(Roles ="admin")]
        public ActionResult Go (int id)
        {
            ViewBag.CustomerId = id;
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Информация для связи:";

            return View();
        }
    }
}