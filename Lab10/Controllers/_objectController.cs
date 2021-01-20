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
    public class _objectController : Controller
    {
        private Model1 db = new Model1();

        // GET: _object
        public ActionResult Index()
        {
            return View(db.objects.ToList());
        }

        // GET: _object/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _object _object = db.objects.Find(id);
            if (_object == null)
            {
                return HttpNotFound();
            }
            return View(_object);
        }

        // GET: _object/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: _object/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] _object _object)
        {
            if (ModelState.IsValid)
            {
                db.objects.Add(_object);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(_object);
        }

        // GET: _object/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _object _object = db.objects.Find(id);
            if (_object == null)
            {
                return HttpNotFound();
            }
            return View(_object);
        }

        // POST: _object/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] _object _object)
        {
            if (ModelState.IsValid)
            {
                db.Entry(_object).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_object);
        }

        // GET: _object/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _object _object = db.objects.Find(id);
            if (_object == null)
            {
                return HttpNotFound();
            }
            return View(_object);
        }

        // POST: _object/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _object _object = db.objects.Find(id);
            db.objects.Remove(_object);
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
