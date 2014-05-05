using BikeRental.Data;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Views
{
    public class MenuController : Controller
    {
        private DataContext db = new DataContext();
        //
        // GET: /Menu/
        [ChildActionOnly] 
        public ActionResult Index()
        {
            List<Tour> bikeTours = db.Tours.Where(x => x.Type == TourType.Bicycle).ToList();
            List<Tour> nycTours = db.Tours.Where(x => x.Type == TourType.NYC).ToList();
            List<Bicycle> bikes = db.Bicycles.ToList();

            ViewBag.bikeTours = bikeTours;
            ViewBag.nycTours = nycTours;
            ViewBag.bikes = bikes;

            return PartialView();
        }
	}
}