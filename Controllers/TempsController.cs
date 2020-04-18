using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demeter_v2.Models;

namespace Demeter_v2.Controllers
{
    public class TempsController : Controller
    {
        private DemeterEntities db = new DemeterEntities();

        // GET: Temps
        public ActionResult Index()
        {
            return View(db.Temps.ToList());
        }

        // GET: Temps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // GET: Temps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Temps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Lat,Lon,Temperature,Date,Time")] Temp temp)
        {
            if (ModelState.IsValid)
            {
                db.Temps.Add(temp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(temp);
        }

        // GET: Temps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // POST: Temps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Lat,Lon,Temperature,Date,Time")] Temp temp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(temp);
        }

        // GET: Temps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temp temp = db.Temps.Find(id);
            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        // POST: Temps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temp temp = db.Temps.Find(id);
            db.Temps.Remove(temp);
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
