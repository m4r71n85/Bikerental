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
        public ActionResult Index()
        {
            CheckoutModel checkoutModel = new CheckoutModel("10", "Description...", "Label....");
            
            return View(checkoutModel);
        }

        public ActionResult FinishCheckOut()
        {
            StringBuilder text = new StringBuilder();
            foreach (string key in Request.Form.Keys)
            {
                string a = Request.Form[key];
                text.AppendLine("[" + key + "]: " + "[" + Request.Form[key] + "]");
            }
            return View(text);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}
