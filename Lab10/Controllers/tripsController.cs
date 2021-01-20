using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab10;

namespace Lab10.Controllers
{
    public class tripsController : Controller
    {
        private Model1 db = new Model1();

        // GET: trips
        public ActionResult Index()
        {
            var trips = db.trips.Include(t => t._object).Include(t => t.car).Include(t => t.object1);
            return View(trips.ToList());
        }

        // GET: trips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trip trip = db.trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: trips/Create
        public ActionResult Create()
        {
            ViewBag.object_form_id = new SelectList(db.objects, "id", "name");
            ViewBag.car_id = new SelectList(db.cars, "id", "name");
            ViewBag.object_to_id = new SelectList(db.objects, "id", "name");
            return View();
        }

        // POST: trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,car_id,object_form_id,object_to_id,date_from,date_to,time")] trip trip)
        {
            if (ModelState.IsValid)
            {
                db.trips.Add(trip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.object_form_id = new SelectList(db.objects, "id", "name", trip.object_form_id);
            ViewBag.car_id = new SelectList(db.cars, "id", "name", trip.car_id);
            ViewBag.object_to_id = new SelectList(db.objects, "id", "name", trip.object_to_id);
            return View(trip);
        }

        // GET: trips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trip trip = db.trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            ViewBag.object_form_id = new SelectList(db.objects, "id", "name", trip.object_form_id);
            ViewBag.car_id = new SelectList(db.cars, "id", "name", trip.car_id);
            ViewBag.object_to_id = new SelectList(db.objects, "id", "name", trip.object_to_id);
            return View(trip);
        }

        // POST: trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,car_id,object_form_id,object_to_id,date_from,date_to,time")] trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.object_form_id = new SelectList(db.objects, "id", "name", trip.object_form_id);
            ViewBag.car_id = new SelectList(db.cars, "id", "name", trip.car_id);
            ViewBag.object_to_id = new SelectList(db.objects, "id", "name", trip.object_to_id);
            return View(trip);
        }

        // GET: trips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            trip trip = db.trips.Find(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            trip trip = db.trips.Find(id);
            db.trips.Remove(trip);
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
