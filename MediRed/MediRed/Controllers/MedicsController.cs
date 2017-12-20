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
    public class MedicsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Medics
        public ActionResult Index()
        {
            var medics = db.Medics.Include(m => m.Country).Include(m => m.Speciality);
            return View(medics.ToList());
        }

        // GET: Medics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        // GET: Medics/Create
        public ActionResult Create()
        {
            ViewBag.IdCountry = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityDescription");
            return View();
        }

        // POST: Medics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,SpecialityId,FirstName,LastName,ContactEmail,ContactNumber,IdCountry")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCountry = new SelectList(db.Countries, "CountryId", "Name", medic.IdCountry);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityDescription", medic.SpecialityId);
            return View(medic);
        }

        // GET: Medics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCountry = new SelectList(db.Countries, "CountryId", "Name", medic.IdCountry);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityDescription", medic.SpecialityId);
            return View(medic);
        }

        // POST: Medics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,SpecialityId,FirstName,LastName,ContactEmail,ContactNumber,IdCountry")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCountry = new SelectList(db.Countries, "CountryId", "Name", medic.IdCountry);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityDescription", medic.SpecialityId);
            return View(medic);
        }

        // GET: Medics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medic medic = db.Medics.Find(id);
            if (medic == null)
            {
                return HttpNotFound();
            }
            return View(medic);
        }

        // POST: Medics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medic medic = db.Medics.Find(id);
            db.Medics.Remove(medic);
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
