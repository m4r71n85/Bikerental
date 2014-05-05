using BikeRental.Data;
using BikeRental.Models;
using BikerRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BikerRental.Web.Controllers
{
    public class FaqsController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /BikeTours/
        public ActionResult Index()
        {
            List<Faq> faqs = db.Faqs.Where(x => x.Enabled == true).ToList();
            ViewBag.faqs = faqs;
            return View();
        }
	}
}