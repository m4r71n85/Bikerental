using BikeRental.Data;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using BikerRental.Web.Helpers;
using System.Data.Entity;
using BikerRental.Web.Models;
 
namespace BikerRental.Web.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Bikerental/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reserve(int id)
        {
            List<Bicycle> bikes = db.Bicycles.Where(x => x.Id != id).ToList();
            Bicycle bike = db.Bicycles.Where(x => x.Id == id).FirstOrDefault();
            ViewBag.bikes = bikes;
            ViewBag.bike = bike;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBikeReservation(int id)
        {
            CartHelper.RemoveBikeReservation(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBikeTourReservation(int id)
        {
            CartHelper.RemoveBikeTourReservation(id);
            return Redirect("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveBusTourReservation(int id)
        {
            CartHelper.RemoveBusTourReservation(id);
            return Redirect("Index");
        }

        public ActionResult Review()
        {
            return View();
        }
	}
}