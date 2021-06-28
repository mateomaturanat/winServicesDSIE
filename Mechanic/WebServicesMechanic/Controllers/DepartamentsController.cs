using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebServicesMechanic.Models;

namespace WebServicesMechanic.Controllers
{
    public class DepartamentsController : Controller
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: Departaments
        public ActionResult Index()
        {
            var departament = db.Departament.Include(d => d.Country);
            return View(departament.ToList());
        }

        // GET: Departaments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departament.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // GET: Departaments/Create
        public ActionResult Create()
        {
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "NameCountry");
            return View();
        }

        // POST: Departaments/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDepartament,NameDepartament,DescriptionDepartament,IdCountry")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Departament.Add(departament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "NameCountry", departament.IdCountry);
            return View(departament);
        }

        // GET: Departaments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departament.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "NameCountry", departament.IdCountry);
            return View(departament);
        }

        // POST: Departaments/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDepartament,NameDepartament,DescriptionDepartament,IdCountry")] Departament departament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCountry = new SelectList(db.Country, "IdCountry", "NameCountry", departament.IdCountry);
            return View(departament);
        }

        // GET: Departaments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departament departament = db.Departament.Find(id);
            if (departament == null)
            {
                return HttpNotFound();
            }
            return View(departament);
        }

        // POST: Departaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departament departament = db.Departament.Find(id);
            db.Departament.Remove(departament);
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
