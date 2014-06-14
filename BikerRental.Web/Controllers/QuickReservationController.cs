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
                    List<BusTour> busTours = db.BusTours.ToList();
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
        public ActionResult AddBikeToursToCart()
        {
            string[] bikeTourIds = Request.Form.GetValues("bikeTourId");
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];
            string email = Request.Form["email"];
            string phoneNumber = Request.Form["phoneNumber"];
            foreach (string _bikeTourId in bikeTourIds)
            {
                int bikeTourId = int.Parse(_bikeTourId);
                DateTime reserveDate = DateTime.Parse(Request.Form["tourDate_"+bikeTourId]);
                ReservedBikeTour reservedTour = new ReservedBikeTour()
                {
                    BikeTourId = bikeTourId,
                    Date = reserveDate,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phoneNumber,
                    Price = db.BikeTours.Find(bikeTourId).OnlinePrice ?? 0
                };

                CartHelper.UserCart.ReservedBikeTours.Add(reservedTour);
                CartHelper.SaveChanges();
            }
            return RedirectToAction("Index", "Cart");
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

        public ActionResult AddBusToursToCart()
        {
            string[] busTourIds = Request.Form.GetValues("busTourId");
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];
            string email = Request.Form["email"];
            string phoneNumber = Request.Form["phoneNumber"];

            foreach (string _busTourId in busTourIds)
            {
                int busTourId = int.Parse(_busTourId);
                DateTime reserveDate = DateTime.Parse(Request.Form["tourDate_" + busTourId]);
                int kids = int.Parse(Request.Form["kids_" + busTourId]);
                int adults = int.Parse(Request.Form["adults_" + busTourId]);

                ReservedBusTour reservedTour = new ReservedBusTour()
                {
                    BusTourId = busTourId,
                    Date = reserveDate,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phoneNumber,
                    Kids = kids,
                    Adults = adults,
                    Price = db.BusTours.Find(busTourId).OnlinePrice ?? 0
                };

                CartHelper.UserCart.ReservedBusTours.Add(reservedTour);
                CartHelper.SaveChanges();
            }
            return RedirectToAction("Index", "Cart");
        }
	}
}