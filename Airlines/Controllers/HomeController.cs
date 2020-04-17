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
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        public ActionResult View2()
        {
            return View();
        }
        [Authorize(Roles ="user")]
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
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}