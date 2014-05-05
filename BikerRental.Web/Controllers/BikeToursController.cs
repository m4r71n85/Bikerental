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
    public class BikeToursController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /BikeTours/
        public ActionResult Index()
        {
            List<Tour> tours = db.Tours.Where(x => x.Type == TourType.Bicycle).Take(5).ToList();
            ViewBag.tours = tours;
            return View();
        }

        public ActionResult Reserve(int id)
        {
            List<Tour> tours = db.Tours.Where(x => x.Type == TourType.Bicycle && x.Id != id).ToList();
            Tour tour = db.Tours.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.tours = tours;
            ViewBag.tour = tour;

            return View();
        }
	}
}