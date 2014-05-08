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

namespace BikerRental.Web.Controllers
{
    public class asassaasController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /asassaas/
        public ActionResult Index()
        {
            var reservedbicycles = db.ReservedBicycles.Include(r => r.Bicycle);
            return View(reservedbicycles.ToList());
        }

        // GET: /asassaas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBicycle reservedbicycle = db.ReservedBicycles.Find(id);
            if (reservedbicycle == null)
            {
                return HttpNotFound();
            }
            return View(reservedbicycle);
        }

        // GET: /asassaas/Create
        public ActionResult Create()
        {
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name");
            return View();
        }

        // POST: /asassaas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Date,Duration,Quantity,Name,Email,Phone,BicycleId")] ReservedBicycle reservedbicycle)
        {
            if (ModelState.IsValid)
            {
                db.ReservedBicycles.Add(reservedbicycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
            return View(reservedbicycle);
        }

        // GET: /asassaas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBicycle reservedbicycle = db.ReservedBicycles.Find(id);
            if (reservedbicycle == null)
            {
                return HttpNotFound();
            }
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
            return View(reservedbicycle);
        }

        // POST: /asassaas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Date,Duration,Quantity,Name,Email,Phone,BicycleId")] ReservedBicycle reservedbicycle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservedbicycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BicycleId = new SelectList(db.Bicycles, "Id", "Name", reservedbicycle.BicycleId);
            return View(reservedbicycle);
        }

        // GET: /asassaas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBicycle reservedbicycle = db.ReservedBicycles.Find(id);
            if (reservedbicycle == null)
            {
                return HttpNotFound();
            }
            return View(reservedbicycle);
        }

        // POST: /asassaas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservedBicycle reservedbicycle = db.ReservedBicycles.Find(id);
            db.ReservedBicycles.Remove(reservedbicycle);
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
