using BikeRental.Data;
using BikeRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data.Entity;

namespace BikerRental.Web.Helpers
{
    public static class CartHelper
    {
        private static DataContext db = null;
        private static DataContext Db {
            get{
                if (db == null)
                {
                    db  = new DataContext();
                }
                return db;
            }
            
        }
        public static Cart UserCart
        {
            get
            {
                string session = HttpContext.Current.Session.SessionID;
                Cart cart = Db.Cart.Where(x => x.SessionId == session).FirstOrDefault();
                if (cart == null)
                {
                    cart = new Cart() { SessionId = session };
                    Db.Cart.Add(cart);
                    Db.SaveChanges();
                }
                return cart;
            }
        }
        public static void SaveChanges(){
            HttpContext.Current.Session.Add("init", true);
            Db.SaveChanges();
        }
        public static int? Quantity()
        {
            int qty = 0;
            List<ReservedBicycle> reservedBikes = Db.ReservedBicycles.ToList();
            List<ReservedTour> reservedTours = Db.ReservedTours.ToList();
            if (reservedBikes != null) {
                qty += reservedBikes.Sum(x => x.Quantity);
            }
            if (reservedTours != null)
            {
                qty += reservedTours.Sum(x => x.Male + x.Female);
            }

            return qty;
        }

        
    }
}