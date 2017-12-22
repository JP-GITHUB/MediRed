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
    public class AttentionsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Attentions
        public ActionResult Index()
        {
            var attentions = db.Attentions.Include(a => a.Diagnostic).Include(a => a.Medic);
            return View(attentions.ToList());
        }

        // GET: Attentions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attention attention = db.Attentions.Find(id);
            if (attention == null)
            {
                return HttpNotFound();
            }
            return View(attention);
        }

        // GET: Attentions/Create
        public ActionResult Create()
        {
            ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description");
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName");
            return View();
        }

        // POST: Attentions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttentionId,Detail,PersonId,DiagnosticId")] Attention attention)
        {
            if (ModelState.IsValid)
            {
                db.Attentions.Add(attention);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", attention.PersonId);
            return View(attention);
        }

        // GET: Attentions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attention attention = db.Attentions.Find(id);
            if (attention == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", attention.PersonId);
            return View(attention);
        }

        // POST: Attentions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AttentionId,Detail,PersonId,DiagnosticId")] Attention attention)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attention).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
            ViewBag.PersonId = new SelectList(db.People, "PersonId", "FirstName", attention.PersonId);
            return View(attention);
        }

        // GET: Attentions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attention attention = db.Attentions.Find(id);
            if (attention == null)
            {
                return HttpNotFound();
            }
            return View(attention);
        }

        // POST: Attentions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attention attention = db.Attentions.Find(id);
            db.Attentions.Remove(attention);
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
