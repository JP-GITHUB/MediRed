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
    public class TechnologistsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Technologists
        public ActionResult Index()
        {
            var people = db.Technologist.Include(t => t.Country).Include(t => t.Laboratory).Include(t => t.Speciality);
            return View(people.ToList());
        }

        // GET: Technologists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologist technologist = db.Technologist.Find(id);
            if (technologist == null)
            {
                return HttpNotFound();
            }
            return View(technologist);
        }

        // GET: Technologists/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.LaboratoryId = new SelectList(db.Laboratories, "LaboratoryId", "Name");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description");
            return View();
        }

        // POST: Technologists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,FirstName,LastName,ContactEmail,ContactNumber,CountryId,SpecialityId,LaboratoryId")] Technologist technologist)
        {
            if (ModelState.IsValid)
            { 
                db.People.Add(technologist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", technologist.CountryId);
            ViewBag.LaboratoryId = new SelectList(db.Laboratories, "LaboratoryId", "Name", technologist.LaboratoryId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", technologist.SpecialityId);
            return View(technologist);
        }

        // GET: Technologists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologist technologist = db.Technologist.Find(id);
            if (technologist == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", technologist.CountryId);
            ViewBag.LaboratoryId = new SelectList(db.Laboratories, "LaboratoryId", "Name", technologist.LaboratoryId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", technologist.SpecialityId);
            return View(technologist);
        }

        // POST: Technologists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,FirstName,LastName,ContactEmail,ContactNumber,CountryId,SpecialityId,LaboratoryId")] Technologist technologist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technologist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", technologist.CountryId);
            ViewBag.LaboratoryId = new SelectList(db.Laboratories, "LaboratoryId", "Name", technologist.LaboratoryId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", technologist.SpecialityId);
            return View(technologist);
        }

        // GET: Technologists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technologist technologist = db.Technologist.Find(id);
            if (technologist == null)
            {
                return HttpNotFound();
            }
            return View(technologist);
        }

        // POST: Technologists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Technologist technologist = db.Technologist.Find(id);
            db.People.Remove(technologist);
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
