using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BikeRental.Models;
using BikeRental.Data;

namespace BikerRental.Web.Areas.Administration.Controllers
{
    public class ToursController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Administration/Tours/
        public ActionResult Index()
        {
            return View(db.Tours.ToList());
        }

        // GET: /Administration/Tours/CreateBikeTour
        public ActionResult CreateBikeTour()
        {
            var tour = new Tour();
            tour.Type = TourType.Bicycle;
            return View(tour);
        }

        // POST: /Administration/Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBikeTour([Bind(Include = "Id,Type,Name,Image,Description,Duration,Schedules,Address1,Address2,DepartureTime,ContactNumber,Notice,OnlinePrice,OnstatePrice,Enabled,RightPanel,HomePage,FrontPage")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tour);
        }

        public ActionResult CreateNycTour()
        {
            var tour = new Tour();
            tour.Type = TourType.NYC;
            return View(tour);
        }

        // POST: /Administration/Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNycTour([Bind(Include = "Id,Type,Name,Image,Description,Duration,Schedules,Address1,Address2,DepartureTime,ContactNumber,Notice,OnlinePrice,OnstatePrice,Enabled,RightPanel,HomePage,FrontPage")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tour);
        }

        // GET: /Administration/Tours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: /Administration/Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Type,Name,Image,Description,Duration,Schedules,Address1,Address2,DepartureTime,ContactNumber,Notice,OnlinePrice,OnstatePrice,Enabled,RightPanel,HomePage,FrontPage")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tour);
        }

        // GET: /Administration/Tours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: /Administration/Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
