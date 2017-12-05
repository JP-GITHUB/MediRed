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
    public class MedicalSpecialitiesController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: MedicalSpecialities
        public ActionResult Index()
        {
            return View(db.MedicalSpecialities.ToList());
        }

        // GET: MedicalSpecialities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalSpeciality medicalSpeciality = db.MedicalSpecialities.Find(id);
            if (medicalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(medicalSpeciality);
        }

        // GET: MedicalSpecialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalSpecialities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecialityId,NameSpeciality")] MedicalSpeciality medicalSpeciality)
        {
            if (ModelState.IsValid)
            {
                db.MedicalSpecialities.Add(medicalSpeciality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalSpeciality);
        }

        // GET: MedicalSpecialities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalSpeciality medicalSpeciality = db.MedicalSpecialities.Find(id);
            if (medicalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(medicalSpeciality);
        }

        // POST: MedicalSpecialities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecialityId,NameSpeciality")] MedicalSpeciality medicalSpeciality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalSpeciality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalSpeciality);
        }

        // GET: MedicalSpecialities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalSpeciality medicalSpeciality = db.MedicalSpecialities.Find(id);
            if (medicalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(medicalSpeciality);
        }

        // POST: MedicalSpecialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalSpeciality medicalSpeciality = db.MedicalSpecialities.Find(id);
            db.MedicalSpecialities.Remove(medicalSpeciality);
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
