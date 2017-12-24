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
    [Authorize]
    public class DiagnosticsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Diagnostics
        public ActionResult Index()
        {
            var diagnostics = db.Diagnostics.Include(d => d.Treatment);
            return View(diagnostics.ToList());
        }

        // GET: Diagnostics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = db.Diagnostics.Find(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            return View(diagnostic);
        }

        // GET: Diagnostics/Create
        public ActionResult Create()
        {
            ViewBag.TreatmentId = new SelectList(db.Treatments, "TreatmentId", "Detail");
            return View();
        }

        // POST: Diagnostics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiagnosticId,Description,RedDiagnostic,TreatmentId")] Diagnostic diagnostic)
        {
            if (ModelState.IsValid)
            {
                db.Diagnostics.Add(diagnostic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TreatmentId = new SelectList(db.Treatments, "TreatmentId", "Detail", diagnostic.TreatmentId);
            return View(diagnostic);
        }

        // GET: Diagnostics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = db.Diagnostics.Find(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            ViewBag.TreatmentId = new SelectList(db.Treatments, "TreatmentId", "Detail", diagnostic.TreatmentId);
            return View(diagnostic);
        }

        // POST: Diagnostics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiagnosticId,Description,RedDiagnostic,TreatmentId")] Diagnostic diagnostic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnostic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TreatmentId = new SelectList(db.Treatments, "TreatmentId", "Detail", diagnostic.TreatmentId);
            return View(diagnostic);
        }

        // GET: Diagnostics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostic diagnostic = db.Diagnostics.Find(id);
            if (diagnostic == null)
            {
                return HttpNotFound();
            }
            return View(diagnostic);
        }

        // POST: Diagnostics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnostic diagnostic = db.Diagnostics.Find(id);
            db.Diagnostics.Remove(diagnostic);
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
