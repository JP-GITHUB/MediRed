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
using System.Web.Configuration;
using System.Diagnostics;

namespace MediRed.Controllers
{
    public class PatientsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewData["MsgError400"] = WebConfigurationManager.AppSettings["MsgError400"];
                return View(WebConfigurationManager.AppSettings["Error400"]);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                ViewData["MsgError404"] = WebConfigurationManager.AppSettings["MsgError404"];
                return View(WebConfigurationManager.AppSettings["Error404"]);
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonId,Diagnostic,Treatment,Name,LastName,Email,Phone")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                ViewData["MsgError400"] = WebConfigurationManager.AppSettings["MsgError400"];
                return View(WebConfigurationManager.AppSettings["Error400"]);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                ViewData["MsgError404"] = WebConfigurationManager.AppSettings["MsgError404"];
                return View(WebConfigurationManager.AppSettings["Error404"]);
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonId,Diagnostic,Treatment,Name,LastName,Email,Phone")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                ViewData["MsgError400"] = WebConfigurationManager.AppSettings["MsgError400"];
                return View(WebConfigurationManager.AppSettings["Error400"]);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                ViewData["MsgError404"] = WebConfigurationManager.AppSettings["MsgError404"];
                return View(WebConfigurationManager.AppSettings["Error404"]);
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
