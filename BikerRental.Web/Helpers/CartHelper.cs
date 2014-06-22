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
        private static string sessionId;
        public static DataContext Db {
            get{
                if (db == null)
                {
                    db  = new DataContext();
                }
                return db;
            }   
        }


        public static string SessionId
        {
            get { return sessionId; }
            set { sessionId = value; }
        }

        public static Cart UserCart
        {
            get
            {
                if (sessionId == null)
                {
                    sessionId = HttpContext.Current.Session.SessionID;
                }

                Cart cart = Db.Cart.Where(x => x.SessionId == sessionId).FirstOrDefault();
                if (cart == null)
                {
                    cart = new Cart() { SessionId = sessionId };
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
            List<ReservedBicycle> reservedBikes = UserCart.ReservedBicycles.ToList();
            List<ReservedBusTour> reservedBusTours = UserCart.ReservedBusTours.ToList();
            int reservedBikeTours = UserCart.ReservedBikeTours.Count();

            if (reservedBikes != null) {
                qty += reservedBikes.Sum(x => x.Quantity);
            }
            if (reservedBusTours != null)
            {
                qty += reservedBusTours.Sum(x => x.Kids + x.Adults);
            }
            qty += reservedBikeTours;

            return qty;
        }

        public static decimal GetTotal()
        {
            decimal total = 0m;
            foreach (ReservedBicycle bike in UserCart.ReservedBicycles.ToList())
            {
                total += bike.Quantity * bike.Price;
            }

            foreach (ReservedBikeTour bikeTour in UserCart.ReservedBikeTours.ToList())
            {
                total += bikeTour.Price;
            }

            foreach (ReservedBusTour busTour in UserCart.ReservedBusTours.ToList())
            {
                total += busTour.Price * busTour.Adults;
                total += busTour.Price * busTour.Kids;
            }
            return total;
        }

        internal static void RemoveBikeReservation(int id)
        {
            ReservedBicycle reservedBike = Db.ReservedBicycles.Find(id);
            Db.ReservedBicycles.Remove(reservedBike);
            Db.SaveChanges();
        }

        internal static void RemoveBikeTourReservation(int id)
        {
            ReservedBikeTour reservedBikeTour = Db.ReservedBikeTours.Find(id);
            Db.ReservedBikeTours.Remove(reservedBikeTour);
            Db.SaveChanges();
        }

        internal static void RemoveBusTourReservation(int id)
        {
            ReservedBusTour reservedBusTour = Db.ReservedBusTours.Find(id);
            Db.ReservedBusTours.Remove(reservedBusTour);
            Db.SaveChanges();
        }

        public static List<ReservedBicycle> GetReservedBikes()
        {
            return Db.ReservedBicycles.Where(x => x.Cart.SessionId == sessionId).Include(x => x.Bicycle).ToList();
        }
        public static List<ReservedBikeTour> GetReservedBikeTours()
        {
            return Db.ReservedBikeTours.Where(x => x.Cart.SessionId == sessionId).Include(x => x.BikeTour).ToList();
        }
        public static List<ReservedBusTour> GetReservetBusTours()
        {
            return Db.ReservedBusTours.Where(x => x.Cart.SessionId == sessionId).Include(x => x.BusTour).ToList();
        }
    }
}