using BikeRental.Data;
using BikeRental.Models;
using BikerRental.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace BikerRental.Web.Controllers
{
    public class FindUsController : Controller
    {
        private DataContext db = new DataContext();

        //
        // GET: /BikeTours/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendMail([Bind(Include = "Name,Email,Subject,Message")] ContactMail mail)
        {
            if (ModelState.IsValid)
            {
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("martin85446@gmail.com", "howareyou8504"),
                    EnableSsl = true
                };
                client.Send(mail.Email, "martin85446@gmail.com", mail.Subject, mail.Message);
            }
            return RedirectToAction("Index");
        }
	}
}