using BikeRental.Data;
using BikeRental.Models;
using BikerRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Controllers
{
    public class BusToursController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /BikeTours/
        public ActionResult Index()
        {
            List<BusTour> tours = db.BusTours.ToList();
            ViewBag.tours = tours;
            return View();
        }

        public ActionResult Reserve(int id)
        {
            List<BusTour> tours = db.BusTours.ToList();
            BusTour tour = db.BusTours.Find(id);
            ViewBag.tours = tours;
            ViewBag.tour = tour;

            return View();
        }
	}
}