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
 
namespace BikerRental.Web.Controllers
{
    public class CartController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /Bikerental/
        public ActionResult Index()
        {

            ViewBag.reservedBikes = db.ReservedBicycles.Where(x => x.Cart.SessionId == Session.SessionID).Include(x => x.Bicycle).ToList();
            ViewBag.reservedBikeTours = db.ReservedBikeTours.Where(x => x.Cart.SessionId == Session.SessionID).Include(x => x.BikeTour).ToList();
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
        //public ActionResult AddToCart(int id)
        //{
        //    Bicycle bike = db.Bicycles.Where(x => x.Id == id).FirstOrDefault();
        //    return View(bike);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddToCart([Bind(Include = "Date,Duration,Quantity,Name,Email,Phone,BicycleId")] ReservedBicycle reservedbicycle)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        decimal? price = db.BicyclePrices.Where(x => x.BicycleId == reservedbicycle.Id && x.Duration == reservedbicycle.Duration).Select(x => x.OnlinePrice).FirstOrDefault();
        //        reservedbicycle.Price = price??0;
        //        CartHelper.UserCart.ReservedBicycles.Add(reservedbicycle);
        //        CartHelper.SaveChanges();
                
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
        //    return View(reservedbicycle);
        //}
	}
}