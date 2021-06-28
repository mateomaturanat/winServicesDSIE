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
    public class ServiceListsController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: ServiceLists
        public ActionResult Index()
        {
            var serviceList = db.ServiceList.Include(s => s.Mechanic).Include(s => s.TheService);
            return View(serviceList.ToList());
        }

        // GET: ServiceLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceList serviceList = db.ServiceList.Find(id);
            if (serviceList == null)
            {
                return HttpNotFound();
            }
            return View(serviceList);
        }

        // GET: ServiceLists/Create
        public ActionResult Create()
        {
            ViewBag.IdMechanic = new SelectList(db.Mechanic, "IdMechanic", "NameMechanic");
            ViewBag.IdTheService = new SelectList(db.TheService, "IdTheService", "NameTheService");
            return View();
        }

        // POST: ServiceLists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdServiceList,CodeServiceList,StatusServiceList,IdMechanic,IdTheService")] ServiceList serviceList)
        {
            if (ModelState.IsValid)
            {
                db.ServiceList.Add(serviceList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdMechanic = new SelectList(db.Mechanic, "IdMechanic", "NameMechanic", serviceList.IdMechanic);
            ViewBag.IdTheService = new SelectList(db.TheService, "IdTheService", "NameTheService", serviceList.IdTheService);
            return View(serviceList);
        }

        // GET: ServiceLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceList serviceList = db.ServiceList.Find(id);
            if (serviceList == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdMechanic = new SelectList(db.Mechanic, "IdMechanic", "NameMechanic", serviceList.IdMechanic);
            ViewBag.IdTheService = new SelectList(db.TheService, "IdTheService", "NameTheService", serviceList.IdTheService);
            return View(serviceList);
        }

        // POST: ServiceLists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdServiceList,CodeServiceList,StatusServiceList,IdMechanic,IdTheService")] ServiceList serviceList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdMechanic = new SelectList(db.Mechanic, "IdMechanic", "NameMechanic", serviceList.IdMechanic);
            ViewBag.IdTheService = new SelectList(db.TheService, "IdTheService", "NameTheService", serviceList.IdTheService);
            return View(serviceList);
        }

        // GET: ServiceLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceList serviceList = db.ServiceList.Find(id);
            if (serviceList == null)
            {
                return HttpNotFound();
            }
            return View(serviceList);
        }

        // POST: ServiceLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceList serviceList = db.ServiceList.Find(id);
            db.ServiceList.Remove(serviceList);
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
