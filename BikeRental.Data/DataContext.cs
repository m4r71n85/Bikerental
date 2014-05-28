using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BikeRental.Models;
using BikeRental.Data.Migrations;

namespace BikeRental.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("BicycleRentalConnection")
        {

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
        }
        public IDbSet<Bicycle> Bicycles { get; set; }
        public IDbSet<BicyclePrices> BicyclePrices { get; set; }
        public IDbSet<BikeTour> BikeTours { get; set; }
        public IDbSet<DoubleDeckerBusTour> BusTours { get; set; }
        public IDbSet<Faq> Faqs { get; set; }
        public IDbSet<Feedback> Feedbacks { get; set; }
        public IDbSet<Page> Pages { get; set; }
        public IDbSet<Tour> Tours { get; set; }
        public IDbSet<Cart> Cart { get; set; }
        public IDbSet<ReservedBicycle> ReservedBicycles { get; set; }
        public IDbSet<ReservedTour> ReservedTours { get; set; }
    }
}
