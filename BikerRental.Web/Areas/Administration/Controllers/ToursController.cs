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
    public class ToursController : BaseController
    {
        private DataContext db = new DataContext();

        // GET: /Administration/Tours/
        public ActionResult Index()
        {
            return View(db.Tours.ToList());
        }

        public ActionResult BikeTours()
        {
            return View(db.Tours.Where(x => x.Type == TourType.Bicycle).ToList());
        }

        public ActionResult NycTours()
        {
            return View(db.Tours.Where(x => x.Type == TourType.NYC).ToList());
        }

        // GET: /Administration/Tours/CreateBikeTour
        public ActionResult CreateBikeTour()
        {
            var tour = new Tour();
            tour.Type = TourType.Bicycle;
            return View(tour);
        }

        // GET: /Administration/Tours/CreateNycTour
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
        [ValidateInput(false)] 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Type,Name,Image,Description,Duration,Schedules,Address1,Address2,DepartureTime,ContactNumber,Notice,OnlinePrice,OnstatePrice,Enabled,RightPanel,HomePage,FrontPage")] Tour tour, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                tour.Image = this.SaveFile(image, ModelState);
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
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Type,Name,Image,Description,Duration,Schedules,Address1,Address2,DepartureTime,ContactNumber,Notice,OnlinePrice,OnstatePrice,Enabled,RightPanel,HomePage,FrontPage")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                if (tour.Type == TourType.Bicycle)
                {
                    return RedirectToAction("BikeTours");
                }
                else
                {
                    return RedirectToAction("NycTours");
                }
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
            if (tour.Type == TourType.Bicycle)
            {
                return RedirectToAction("BikeTours");
            }
            else
            {
                return RedirectToAction("NycTours");
            }
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
