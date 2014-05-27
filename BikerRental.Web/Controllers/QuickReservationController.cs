using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeRental.Models;
using BikerRental.Web.ViewModels;
using BikeRental.Data;

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
                    List<BikeTour> tours = db.BikeTours.ToList();
                    return PartialView("_BikeTours", tours);
                case TourOrRental.DoubleDeckerBusTour:
                    break;
                case TourOrRental.Cruise:
                    break;
                case TourOrRental.Packages:
                    break;
                default:
                    break;
            }
            return PartialView("_BikeRental");
        }
	}
}