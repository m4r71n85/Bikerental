using BikeRental.Data;
using BikeRental.Models;
using BikerRental.Web.Helpers;
using BikerRental.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult Index()
        {   
            return View();
        }
        
        //[HttpPost]
        public ActionResult FinishCheckOut()
        {
            StringBuilder text = LogFinishCheckout();
            int transactionStatus = int.Parse(Request.Form["x_response_code"]);
            if (transactionStatus == 1)
            {
                List<ReservedBicycle> reservedBikes = CartHelper.UserCart.ReservedBicycles.ToList();
                List<ReservedBikeTour> reservedBikeTours = CartHelper.UserCart.ReservedBikeTours.ToList();
                List<ReservedBusTour> reservedBusTours = CartHelper.UserCart.ReservedBusTours.ToList();
                CartHelper.SessionId = Request.Form["x_id"];
                
                //this context and CartHelper context are two different! make it with one
                Order order = new Order();
                order.ReservedBicycles = reservedBikes;
                order.ReservedBikeTours = reservedBikeTours;
                order.ReservedBusTours = reservedBusTours;
                order.SessionId = CartHelper.SessionId;
                order.AccountNumber = Request.Form["x_account_number"];
                order.Amount = Request.Form["x_amount"];
                order.CardType = Request.Form["x_card_type"];
                order.City = Request.Form["x_city"];
                order.Country = Request.Form["x_country"];
                order.Desciption = Request.Form["x_description"];
                order.Email = Request.Form["x_email"];
                order.FirstName = Request.Form["x_first_name"];
                order.LastName = Request.Form["x_last_name"];
                order.Phone = Request.Form["x_phone"];
                order.SecureKey = Request.Form["x_secure_key"];
                order.LocalSecureKey = CheckoutModel.CustomVerification;
                order.State = Request.Form["x_ship_to_state"];
                order.Status = transactionStatus;
                CartHelper.Db.Orders.Add(order);

                foreach (ReservedBicycle reservedBike in reservedBikes)
                {
                    reservedBike.Cart = null;
                }
                foreach (ReservedBikeTour reservedBikeTour in reservedBikeTours)
                {
                    reservedBikeTour.Cart = null;
                } 
                foreach (ReservedBusTour reservedBus in reservedBusTours)
                {
                    reservedBus.Cart = null;
                }
                CartHelper.Db.SaveChanges();
            }

            return View(transactionStatus);
        }

        private StringBuilder LogFinishCheckout()
        {
            StringBuilder text = new StringBuilder();
            foreach (string key in Request.Form.Keys)
            {
                string a = Request.Form[key];
                text.AppendLine("[" + key + "]: " + Request.Form[key]);
            }
            Log log = new Log();

            log.Code = 1;
            log.Title = "";
            if (Request.UrlReferrer != null)
            {
                log.Title = Request.UrlReferrer.AbsoluteUri;
            }
            log.Body = text.ToString();
            db.Logs.Add(log);
            db.SaveChanges();
            return text;
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
