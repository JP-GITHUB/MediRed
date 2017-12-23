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
            var people = db.Medics.Include(m => m.Country).Include(m => m.AtentionCenter).Include(m => m.Speciality);
            return View(people.ToList());
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
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.AtentionCenterId = new SelectList(db.AtentionCenters, "AtentionCenterId", "Address");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description");
            return View();
        }

        // POST: Medics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ContactEmail,ContactNumber,CountryId,SpecialityId,AtentionCenterId")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Medics.Add(medic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", medic.CountryId);
            ViewBag.AtentionCenterId = new SelectList(db.AtentionCenters, "AtentionCenterId", "Address", medic.AtentionCenterId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", medic.SpecialityId);
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
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", medic.CountryId);
            ViewBag.AtentionCenterId = new SelectList(db.AtentionCenters, "AtentionCenterId", "Address", medic.AtentionCenterId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", medic.SpecialityId);
            return View(medic);
        }

        // POST: Medics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ContactEmail,ContactNumber,CountryId,SpecialityId,AtentionCenterId")] Medic medic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", medic.CountryId);
            ViewBag.AtentionCenterId = new SelectList(db.AtentionCenters, "AtentionCenterId", "Address", medic.AtentionCenterId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", medic.SpecialityId);
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
