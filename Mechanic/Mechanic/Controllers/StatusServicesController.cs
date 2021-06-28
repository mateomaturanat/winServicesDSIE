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
    public class StatusServicesController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: StatusServices
        public ActionResult Index()
        {
            return View(db.StatusService.ToList());
        }

        // GET: StatusServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusService statusService = db.StatusService.Find(id);
            if (statusService == null)
            {
                return HttpNotFound();
            }
            return View(statusService);
        }

        // GET: StatusServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusServices/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStatusService,NameStatusService,DescriptionStatusService")] StatusService statusService)
        {
            if (ModelState.IsValid)
            {
                db.StatusService.Add(statusService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusService);
        }

        // GET: StatusServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusService statusService = db.StatusService.Find(id);
            if (statusService == null)
            {
                return HttpNotFound();
            }
            return View(statusService);
        }

        // POST: StatusServices/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStatusService,NameStatusService,DescriptionStatusService")] StatusService statusService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusService);
        }

        // GET: StatusServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusService statusService = db.StatusService.Find(id);
            if (statusService == null)
            {
                return HttpNotFound();
            }
            return View(statusService);
        }

        // POST: StatusServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusService statusService = db.StatusService.Find(id);
            db.StatusService.Remove(statusService);
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
