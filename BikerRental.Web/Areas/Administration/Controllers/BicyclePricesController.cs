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
    public class BicyclePricesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /Administration/BicyclePrices/
        public ActionResult Index()
        {
            var bicycleprices = db.BicyclePrices.Include(b => b.Bicycle);
            return View(bicycleprices.ToList());
        }

        // GET: /Administration/BicyclePrices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicyclePrices bicycleprices = db.BicyclePrices.Find(id);
            if (bicycleprices == null)
            {
                return HttpNotFound();
            }
            return View(bicycleprices);
        }

        // GET: /Administration/BicyclePrices/Create
        public ActionResult Create()
        {
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name");
            return View();
        }

        // POST: /Administration/BicyclePrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,OnlinePrice,OnstatePrice,Duration,BicycleId")] BicyclePrices bicycleprices)
        {
            if (ModelState.IsValid)
            {
                db.BicyclePrices.Add(bicycleprices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", bicycleprices.BicycleId);
            return View(bicycleprices);
        }

        // GET: /Administration/BicyclePrices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicyclePrices bicycleprices = db.BicyclePrices.Find(id);
            if (bicycleprices == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", bicycleprices.BicycleId);
            return View(bicycleprices);
        }

        // POST: /Administration/BicyclePrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,OnlinePrice,OnstatePrice,Duration,BicycleId")] BicyclePrices bicycleprices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bicycleprices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", bicycleprices.BicycleId);
            return View(bicycleprices);
        }

        // GET: /Administration/BicyclePrices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BicyclePrices bicycleprices = db.BicyclePrices.Find(id);
            if (bicycleprices == null)
            {
                return HttpNotFound();
            }
            return View(bicycleprices);
        }

        // POST: /Administration/BicyclePrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BicyclePrices bicycleprices = db.BicyclePrices.Find(id);
            db.BicyclePrices.Remove(bicycleprices);
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
