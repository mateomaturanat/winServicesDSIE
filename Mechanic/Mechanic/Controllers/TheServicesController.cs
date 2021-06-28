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
    public class TheServicesController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: TheServices
        public ActionResult Index()
        {
            var theService = db.TheService.Include(t => t.ServiceType);
            return View(theService.ToList());
        }

        // GET: TheServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheService theService = db.TheService.Find(id);
            if (theService == null)
            {
                return HttpNotFound();
            }
            return View(theService);
        }

        // GET: TheServices/Create
        public ActionResult Create()
        {
            ViewBag.IdServiceType = new SelectList(db.ServiceType, "IdServiceType", "NameServiceType");
            return View();
        }

        // POST: TheServices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTheService,NameTheService,DescriptionTheService,PreviewImageTheService,IdServiceType")] TheService theService)
        {
            if (ModelState.IsValid)
            {
                db.TheService.Add(theService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdServiceType = new SelectList(db.ServiceType, "IdServiceType", "NameServiceType", theService.IdServiceType);
            return View(theService);
        }

        // GET: TheServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheService theService = db.TheService.Find(id);
            if (theService == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdServiceType = new SelectList(db.ServiceType, "IdServiceType", "NameServiceType", theService.IdServiceType);
            return View(theService);
        }

        // POST: TheServices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTheService,NameTheService,DescriptionTheService,PreviewImageTheService,IdServiceType")] TheService theService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(theService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdServiceType = new SelectList(db.ServiceType, "IdServiceType", "NameServiceType", theService.IdServiceType);
            return View(theService);
        }

        // GET: TheServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheService theService = db.TheService.Find(id);
            if (theService == null)
            {
                return HttpNotFound();
            }
            return View(theService);
        }

        // POST: TheServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheService theService = db.TheService.Find(id);
            db.TheService.Remove(theService);
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
