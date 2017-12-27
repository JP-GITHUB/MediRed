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
using MediRed.Utilities;
using System.Net.Mail;

namespace MediRed.Controllers
{
    [Authorize]
    public class AttentionsController : Controller
    {
        private MediRedContext db = new MediRedContext();

        // GET: Attentions
        public ActionResult Index()
        {
            var attentions = db.Attentions.Include(a => a.Diagnostic).Include(a => a.History).Include(a => a.Medic);
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
            ViewBag.HistoryId = new SelectList(db.Histories, "HistoryId", "PatientName");
            ViewBag.Id = new SelectList(db.Patients, "Id", "FirstName");
            return View();
        }

        // POST: Attentions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AttentionId,Detail,Id,DiagnosticId,HistoryId")] Attention attention)
        {
            if (ModelState.IsValid)
            {
                var histo = db.Histories.Where(x => x.Id == attention.Id).FirstOrDefault();
                attention.HistoryId = histo.HistoryId;
                var medic = db.Medics.Where(x => x.ContactEmail == this.User.Identity.Name).FirstOrDefault();
                attention.Id = medic.Id;
                db.Attentions.Add(attention);
                db.SaveChanges();
                var Di = db.Diagnostics.Where(x => x.DiagnosticId == attention.DiagnosticId).FirstOrDefault();
                //mensajeria
                if (Di.RedDiagnostic)
                {
                    var patient = db.Patients.Where(x => x.Id == histo.Id).FirstOrDefault();
                    var mail = patient.ContactEmail;
                    Notification msg = new Notification();
                    MailMessage mnsj = new MailMessage();
                    mnsj.Subject = "Mensaje Urgente [Medired]";
                    mnsj.To.Add(new MailAddress(mail));
                    mnsj.From = new MailAddress("MediredMsg@gmail.com", "Equipo Medired");
                    mnsj.Body = "Estimado Paciente \n\n Necesitamos que se comunique con su medico \n a la brevedad\n\n " +
                                            "Su diagnostico requiere de atencion especial. \n\n\n\n Medired - Nos preocupamos por ti";
                    /* Enviar */
                    msg.MandarCorreo(mnsj);

                }

                return RedirectToAction("Index");
            }

            ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
            ViewBag.HistoryId = new SelectList(db.Histories, "HistoryId", "PatientName", attention.HistoryId);
            ViewBag.Id = new SelectList(db.People, "Id", "FirstName", attention.Id);
            return View(attention);
        }

        //// GET: Attentions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Attention attention = db.Attentions.Find(id);
        //    if (attention == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
        //    ViewBag.HistoryId = new SelectList(db.Histories, "HistoryId", "PatientName", attention.HistoryId);
        //    ViewBag.Id = new SelectList(db.People, "Id", "FirstName", attention.Id);
        //    return View(attention);
        //}

        //// POST: Attentions/Edit/5
        //// Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        //// más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "AttentionId,Detail,Id,DiagnosticId,HistoryId")] Attention attention)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(attention).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.DiagnosticId = new SelectList(db.Diagnostics, "DiagnosticId", "Description", attention.DiagnosticId);
        //    ViewBag.HistoryId = new SelectList(db.Histories, "HistoryId", "PatientName", attention.HistoryId);
        //    ViewBag.Id = new SelectList(db.People, "Id", "FirstName", attention.Id);
        //    return View(attention);
        //}

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
