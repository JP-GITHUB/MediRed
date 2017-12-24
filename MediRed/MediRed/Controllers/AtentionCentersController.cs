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
    public class AtentionCentersController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: AtentionCenters
        public ActionResult Index()
        {
            var atentionCenters = db.AtentionCenters.Include(a => a.Provider);
            return View(atentionCenters.ToList());
        }

        // GET: AtentionCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtentionCenter atentionCenter = db.AtentionCenters.Find(id);
            if (atentionCenter == null)
            {
                return HttpNotFound();
            }
            return View(atentionCenter);
        }

        // GET: AtentionCenters/Create
        public ActionResult Create()
        {
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name");
            return View();
        }

        // POST: AtentionCenters/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AtentionCenterId,Address,PhoneCener,ProviderId")] AtentionCenter atentionCenter)
        {
            if (ModelState.IsValid)
            {
                db.AtentionCenters.Add(atentionCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", atentionCenter.ProviderId);
            return View(atentionCenter);
        }

        // GET: AtentionCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtentionCenter atentionCenter = db.AtentionCenters.Find(id);
            if (atentionCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", atentionCenter.ProviderId);
            return View(atentionCenter);
        }

        // POST: AtentionCenters/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AtentionCenterId,Address,PhoneCener,ProviderId")] AtentionCenter atentionCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atentionCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProviderId = new SelectList(db.Providers, "ProviderId", "Name", atentionCenter.ProviderId);
            return View(atentionCenter);
        }

        // GET: AtentionCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AtentionCenter atentionCenter = db.AtentionCenters.Find(id);
            if (atentionCenter == null)
            {
                return HttpNotFound();
            }
            return View(atentionCenter);
        }

        // POST: AtentionCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AtentionCenter atentionCenter = db.AtentionCenters.Find(id);
            db.AtentionCenters.Remove(atentionCenter);
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
