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
    public class WellfaresController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Wellfares
        public ActionResult Index()
        {
            return View(db.Wellfares.ToList());
        }

        // GET: Wellfares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wellfare wellfare = db.Wellfares.Find(id);
            if (wellfare == null)
            {
                return HttpNotFound();
            }
            return View(wellfare);
        }

        // GET: Wellfares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wellfares/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WellfareId,name,detail")] Wellfare wellfare)
        {
            if (ModelState.IsValid)
            {
                db.Wellfares.Add(wellfare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wellfare);
        }

        // GET: Wellfares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wellfare wellfare = db.Wellfares.Find(id);
            if (wellfare == null)
            {
                return HttpNotFound();
            }
            return View(wellfare);
        }

        // POST: Wellfares/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WellfareId,name,detail")] Wellfare wellfare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wellfare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wellfare);
        }

        // GET: Wellfares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wellfare wellfare = db.Wellfares.Find(id);
            if (wellfare == null)
            {
                return HttpNotFound();
            }
            return View(wellfare);
        }

        // POST: Wellfares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wellfare wellfare = db.Wellfares.Find(id);
            db.Wellfares.Remove(wellfare);
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
