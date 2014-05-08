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
    public class CancellationPolicyController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}