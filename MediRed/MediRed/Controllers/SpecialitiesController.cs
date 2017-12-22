using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediRed.Context;
using MediRed.Models;

namespace MediRed.Controllers
{
    public class SpecialitiesController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Specialities
        public ActionResult Index()
        {
            return View(db.Specialities.ToList());
        }

        // GET: Specialities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // GET: Specialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specialities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecialityId,Description")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Specialities.Add(speciality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(speciality);
        }

        // GET: Specialities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecialityId,Description")] Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speciality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(speciality);
        }

        // GET: Specialities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Speciality speciality = db.Specialities.Find(id);
            if (speciality == null)
            {
                return HttpNotFound();
            }
            return View(speciality);
        }

        // POST: Specialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Speciality speciality = db.Specialities.Find(id);
            db.Specialities.Remove(speciality);
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
