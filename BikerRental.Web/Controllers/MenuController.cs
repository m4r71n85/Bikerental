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
            List<Bicycle> bikes = db.Bicycles.ToList();
            List<BikeTour> bikeTours = db.BikeTours.ToList();
            List<DoubleDeckerBusTour> busTours = db.BusTours.ToList();

            ViewBag.bikeTours = bikeTours;
            ViewBag.busTours = busTours;
            ViewBag.bikes = bikes;

            return PartialView();
        }
	}
}