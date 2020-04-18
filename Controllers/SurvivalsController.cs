﻿using System;
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
    public class SurvivalsController : Controller
    {
        private DemeterEntities db = new DemeterEntities();

        // GET: Survivals
        public ActionResult Index()
        {
            return View(db.Survivals.ToList());
        }

        // GET: Survivals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survival survival = db.Survivals.Find(id);
            if (survival == null)
            {
                return HttpNotFound();
            }
            return View(survival);
        }

        // GET: Survivals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Survivals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Intensity,Seeding,Area,SurvivalResult")] Survival survival)
        {
            if (ModelState.IsValid)
            {
                db.Survivals.Add(survival);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(survival);
        }

        // GET: Survivals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survival survival = db.Survivals.Find(id);
            if (survival == null)
            {
                return HttpNotFound();
            }
            return View(survival);
        }

        // POST: Survivals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Intensity,Seeding,Area,SurvivalResult")] Survival survival)
        {
            if (ModelState.IsValid)
            {
                db.Entry(survival).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(survival);
        }

        // GET: Survivals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Survival survival = db.Survivals.Find(id);
            if (survival == null)
            {
                return HttpNotFound();
            }
            return View(survival);
        }

        // POST: Survivals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Survival survival = db.Survivals.Find(id);
            db.Survivals.Remove(survival);
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
