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

            //if (Request.Form["x_response_code"] == "1")
            //{
                //CartHelper.SessionId = Request.Form["x_id"];
            
            //this context and CartHelper context are two different! make it with one
                Order order = new Order();
                order.ReservedBicycles = CartHelper.UserCart.ReservedBicycles;
                order.ReservedBikeTours = CartHelper.UserCart.ReservedBikeTours;
                order.ReservedBusTours = CartHelper.UserCart.ReservedBusTours;
                order.SessionId = CartHelper.SessionId;
                order.Status = 1;
                CartHelper.Db.Orders.Add(order);
                CartHelper.Db.SaveChanges();
                return RedirectToAction("Success");
            //}

            return View(text);
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
