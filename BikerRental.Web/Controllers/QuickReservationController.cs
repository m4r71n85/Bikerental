using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeRental.Models;
using BikerRental.Web.ViewModels;
using BikeRental.Data;
using BikerRental.Web.Helpers;

namespace BikerRental.Web.QuickReservation
{
    public class QuickReservationController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /QuickReservation/
        public PartialViewResult ChooseTourOrRental(TourOrRental tourOrRental)
        {
            switch (tourOrRental)
            {
                case TourOrRental.BikeRental:
                    List<Bicycle> bikes = db.Bicycles.ToList();
                    return PartialView("_BikeRental", bikes);
                case TourOrRental.BikeTour:
                    List<BikeTour> bikeTours = db.BikeTours.ToList();
                    return PartialView("_BikeTours", bikeTours);
                case TourOrRental.DoubleDeckerBusTour:
                    List<DoubleDeckerBusTour> busTours = db.BusTours.ToList();
                    return PartialView("_BusTours", busTours);
                case TourOrRental.Cruise:
                    break;
                case TourOrRental.Packages:
                    break;
                default:
                    return null;
            }
            return PartialView("_BikeRental");
        }

        [HttpPost]
        public ActionResult AddBikesToCart()
        {
            string[] bikeIds = Request.Form.GetValues("bikeId");
            DateTime rentDate = DateTime.Parse(Request.Form["date"]);
            string duration = Request.Form["duration"];
            string name = Request.Form["name"];
            string email = Request.Form["email"];
            string phoneNumber = Request.Form["phoneNumber"];

            foreach (string bikeId in bikeIds)
            {
                int quantity = int.Parse(Request.Form["quantity_"+bikeId]);
                ReservedBicycle reservedbicycle = new ReservedBicycle()
                {
                    BicycleId = int.Parse(bikeId),
                    Date = rentDate,
                    Duration = duration,
                    Email = email,
                    Name = name,
                    Phone = phoneNumber,
                    Quantity = quantity
                };
                var a = db.BicyclePrices
                    .Where(x => x.BicycleId == reservedbicycle.BicycleId && x.Duration.Equals(reservedbicycle.Duration)).ToList();

                decimal price = db.BicyclePrices
                    .Where(x => x.BicycleId ==reservedbicycle.BicycleId && x.Duration.Equals(reservedbicycle.Duration))
                    .Select(x => x.OnlinePrice).FirstOrDefault() ?? 0;
                reservedbicycle.Price = price;
                CartHelper.UserCart.ReservedBicycles.Add(reservedbicycle);
                CartHelper.SaveChanges();
            }
            

            //ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
            return RedirectToAction("Index", "Cart");
        } 
	}
}