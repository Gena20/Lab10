using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab10.Controllers
{
    public class HomeController : Controller
    {
        Model1 model = new Model1();
        public ActionResult Trips()
        {
            ViewBag.Message = "Trips";
            var trips = model.trips.ToList();
            foreach (var trip in trips)
            {
                trip.time = (trip.date_to - trip.date_from);
            }

            return View(trips);
        }

        public ActionResult Cars()
        {
            ViewBag.Message = "Cars";
            var cars = model.cars.ToList();

            return View(cars);
        }

        public ActionResult Objects()
        {
            ViewBag.Message = "Objects";
            var objects = model.objects.ToList();

            return View(objects);
        }
    }
}