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
    public class ServicesController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: Services
        public ActionResult Index()
        {
            var service = db.Service.Include(s => s.Client).Include(s => s.ServiceList).Include(s => s.StatusService);
            return View(service.ToList());
        }

        // GET: Services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Services/Create
        public ActionResult Create()
        {
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "NameClient");
            ViewBag.IdServiceList = new SelectList(db.ServiceList, "IdServiceList", "CodeServiceList");
            ViewBag.IdStatusService = new SelectList(db.StatusService, "IdStatusService", "NameStatusService");
            return View();
        }

        // POST: Services/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdService,CreatedDateService,DeletCodeService,MechanicCommentService,ClientCommentService,MechanicCalificationService,ClientCalificationService,IdClient,IdServiceList,IdStatusService")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Service.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "NameClient", service.IdClient);
            ViewBag.IdServiceList = new SelectList(db.ServiceList, "IdServiceList", "CodeServiceList", service.IdServiceList);
            ViewBag.IdStatusService = new SelectList(db.StatusService, "IdStatusService", "NameStatusService", service.IdStatusService);
            return View(service);
        }

        // GET: Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "NameClient", service.IdClient);
            ViewBag.IdServiceList = new SelectList(db.ServiceList, "IdServiceList", "CodeServiceList", service.IdServiceList);
            ViewBag.IdStatusService = new SelectList(db.StatusService, "IdStatusService", "NameStatusService", service.IdStatusService);
            return View(service);
        }

        // POST: Services/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdService,CreatedDateService,DeletCodeService,MechanicCommentService,ClientCommentService,MechanicCalificationService,ClientCalificationService,IdClient,IdServiceList,IdStatusService")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Client, "IdClient", "NameClient", service.IdClient);
            ViewBag.IdServiceList = new SelectList(db.ServiceList, "IdServiceList", "CodeServiceList", service.IdServiceList);
            ViewBag.IdStatusService = new SelectList(db.StatusService, "IdStatusService", "NameStatusService", service.IdStatusService);
            return View(service);
        }

        // GET: Services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Service.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Service.Find(id);
            db.Service.Remove(service);
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
