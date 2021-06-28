using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mechanic.Models;

namespace Mechanic.Controllers
{
    public class MechanicsController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: Mechanics
        public ActionResult Index()
        {
            var mechanic = db.Mechanic.Include(m => m.City).Include(m => m.TypeDocument);
            return View(mechanic.ToList());
        }

        // GET: Mechanics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic.Models.Mechanic mechanic = db.Mechanic.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // GET: Mechanics/Create
        public ActionResult Create()
        {
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity");
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument");
            return View();
        }

        // POST: Mechanics/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMechanic,NameMechanic,SurnameMechanic,DocumentNumberMechanic,GenderMechanic,PhoneMechanic,EmailMechanic,ProfilePictureMechanic,LatitudeMechanic,LongitudeMechanic,IdCity,IdTypeDocument")] Mechanic.Models.Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                db.Mechanic.Add(mechanic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", mechanic.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", mechanic.IdTypeDocument);
            return View(mechanic);
        }

        // GET: Mechanics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic.Models.Mechanic mechanic = db.Mechanic.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", mechanic.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", mechanic.IdTypeDocument);
            return View(mechanic);
        }

        // POST: Mechanics/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMechanic,NameMechanic,SurnameMechanic,DocumentNumberMechanic,GenderMechanic,PhoneMechanic,EmailMechanic,ProfilePictureMechanic,LatitudeMechanic,LongitudeMechanic,IdCity,IdTypeDocument")] Mechanic.Models.Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mechanic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", mechanic.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", mechanic.IdTypeDocument);
            return View(mechanic);
        }

        // GET: Mechanics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mechanic.Models.Mechanic mechanic = db.Mechanic.Find(id);
            if (mechanic == null)
            {
                return HttpNotFound();
            }
            return View(mechanic);
        }

        // POST: Mechanics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mechanic.Models.Mechanic mechanic = db.Mechanic.Find(id);
            db.Mechanic.Remove(mechanic);
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
