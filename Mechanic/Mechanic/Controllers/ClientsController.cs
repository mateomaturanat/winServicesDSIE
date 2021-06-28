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
    public class ClientsController : Controller
    {
        private ProyectoDelCursoEntities db = new ProyectoDelCursoEntities();

        // GET: Clients
        public ActionResult Index()
        {
            var client = db.Client.Include(c => c.City).Include(c => c.TypeDocument);
            return View(client.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity");
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument");
            return View();
        }

        // POST: Clients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClient,NameClient,SurnameClient,IdentificationNumberClient,GenderClient,PhoneClient,VehicleClient,ProfilePictureClient,Latitude,Longitude,IdCity,IdTypeDocument")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Client.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", client.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", client.IdTypeDocument);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", client.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", client.IdTypeDocument);
            return View(client);
        }

        // POST: Clients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClient,NameClient,SurnameClient,IdentificationNumberClient,GenderClient,PhoneClient,VehicleClient,ProfilePictureClient,Latitude,Longitude,IdCity,IdTypeDocument")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCity = new SelectList(db.City, "IdCity", "NameCity", client.IdCity);
            ViewBag.IdTypeDocument = new SelectList(db.TypeDocument, "IdTypeDocument", "NameDocument", client.IdTypeDocument);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
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
