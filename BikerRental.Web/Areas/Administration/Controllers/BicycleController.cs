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
using System.IO;
using ImageResizer;

namespace BikerRental.Web.Areas.Administration.Controllers
{
    public class BicycleController : BaseController
    {
        private DataContext db = new DataContext();

        // GET: /Administration/Bicycle/
        public ActionResult Index()
        {
            return View(db.Bicycles.ToList());
        }

        // GET: /Administration/Bicycle/Create
        public ActionResult Create()
        {
            Bicycle bicycle = new Bicycle();
            bicycle.CreateBicyclePrices(5);
            return View(bicycle);
        }

        // POST: /Administration/Bicycle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)] 
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Image,Description,FrontPage,Hidden,Prices")] Bicycle bicycle, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                bicycle.Image = this.SaveFile(image, ModelState);
                db.Bicycles.Add(bicycle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bicycle);
        }

        // GET: /Administration/Bicycle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicycle bicycle = db.Bicycles.Find(id);
            if (bicycle == null)
            {
                return HttpNotFound();
            }
            return View(bicycle);
        }

        // POST: /Administration/Bicycle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)] 
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Description,FrontPage,Hidden,Prices")] Bicycle bicycle, HttpPostedFileBase image)
        {
            string fileName = this.SaveFile(image, ModelState);
            if (fileName != null) {
                this.DeleteFile(bicycle.Image);
                bicycle.Image = fileName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(bicycle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bicycle);
        }

        // GET: /Administration/Bicycle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bicycle bicycle = db.Bicycles.Find(id);
            if (bicycle == null)
            {
                return HttpNotFound();
            }
            return View(bicycle);
        }

        // POST: /Administration/Bicycle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bicycle bicycle = db.Bicycles.Find(id);
            db.Bicycles.Remove(bicycle);
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
