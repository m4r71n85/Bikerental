using BikeRental.Data;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using BikerRental.Web.Helpers;

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

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            Bicycle bike = db.Bicycles.Where(x => x.Id == id).FirstOrDefault();
            return View(bike);
        }

        [HttpGet]
        public ActionResult ExcludeFromCart(int id)
        {
            ReservedBicycle bike = db.ReservedBicycles.Find(id);
            if (bike != null) { 
                db.ReservedBicycles.Remove(bike);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Cart");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBikeToCart([Bind(Include = "Date,Duration,Quantity,Name,Email,Phone,BicycleId")] ReservedBicycle reservedbicycle)
        {
            if (ModelState.IsValid)
            {
                decimal price = db.BicyclePrices.Where(x => x.BicycleId == reservedbicycle.BicycleId && x.Duration == reservedbicycle.Duration).Select(x => x.OnlinePrice).FirstOrDefault() ?? 0;
                reservedbicycle.Price = price;
                CartHelper.UserCart.ReservedBicycles.Add(reservedbicycle);
                CartHelper.SaveChanges();

                //ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
                return RedirectToAction("Index", "Cart");
                    
            }

            return RedirectToAction("Index");
            
        }
	}
}