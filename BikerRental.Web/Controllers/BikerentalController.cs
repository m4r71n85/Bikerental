using BikeRental.Data;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Controllers
{
    public class BikerentalController : Controller
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

        public ActionResult AddToCart(int id)
        {
            Bicycle bike = db.Bicycles.Where(x => x.Id == id).FirstOrDefault();
            return View(bike);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart([Bind(Include = "Date,Duration,Quantity,Name,Email,Phone,BicycleId")] ReservedBicycle reservedbicycle)
        {
            if (ModelState.IsValid)
            {
                db.ReservedBicycles.Add(reservedbicycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
            return View(reservedbicycle);
        }
	}
}