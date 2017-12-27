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
using Microsoft.AspNet.Identity;
//
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Collections;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;

namespace MediRed.Controllers
{
    [Authorize]
    public class TechnologistsController : Controller
    {
        private MediRedContext db = new MediRedContext();
        private ApplicationDbContext ddb = new ApplicationDbContext();

        // GET: Technologists
        public ActionResult Index()
        {
            var technologist = db.Technologist.ToList();
            return View(technologist);
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
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,ContactEmail,ContactNumber,Rut,CountryId,SpecialityId,LaboratoryId, Password")] Technologist technologist)
        {
            if (ModelState.IsValid)
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ddb));
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ddb));

                var user = new ApplicationUser { UserName = technologist.ContactEmail, Email = technologist.ContactEmail };
                var result = UserManager.Create(user, technologist.Password);
                if (result.Succeeded)
                {   //creo al paciente con los datos del usuario registrado
                    Technologist nt = new Technologist();
                    nt.FirstName = technologist.FirstName;
                    nt.LastName = technologist.LastName;
                    nt.ContactEmail = technologist.ContactEmail;
                    nt.CountryId = technologist.CountryId;
                    nt.Rut = technologist.Rut;
                    nt.ContactNumber = technologist.ContactNumber;
                    nt.LaboratoryId = technologist.LaboratoryId;
                    nt.SpecialityId = technologist.SpecialityId;
                    nt.Password = user.PasswordHash;
                    //guardo al nuevo paciente
                    var dbTech = db.Technologist;
                    dbTech.Add(nt);
                    db.SaveChanges();
                    //Asignacion de rol
                    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ddb));
                    var userRol = userManager.FindByName(nt.ContactEmail);
                    userManager.AddToRole(userRol.Id, "Tecnologo");
                    //redireciono
                    return RedirectToAction("Index");
                }
                ViewBag.message = result.Errors;
                ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", technologist.CountryId);
                ViewBag.LaboratoryId = new SelectList(db.Laboratories, "LaboratoryId", "Name", technologist.LaboratoryId);
                ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "Description", technologist.SpecialityId);
                return View(technologist);
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,ContactEmail,ContactNumber,Rut,CountryId,SpecialityId,LaboratoryId")] Technologist technologist)
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

            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(ddb));
            var user = UserManager.FindByEmail(technologist.ContactEmail);
            UserManager.Delete(user);

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
