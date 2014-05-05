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
    public class FeedbacksController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /BikeTours/
        public ActionResult Index()
        {
            List<Feedback> feedbacks = db.Feedbacks.Where(x=>x.Enabled == true).ToList();
            ViewBag.feedbacks = feedbacks;
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Title,Description,CreatedAt,Rating,FirstName,LastName,Email,Enabled")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Enabled = true;
                db.Feedbacks.Add(feedback);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
	}
}