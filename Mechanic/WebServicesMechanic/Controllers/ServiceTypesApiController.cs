using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServicesMechanic.Models;

namespace WebServicesMechanic.Controllers
{
    public class ServiceTypesApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/ServiceTypesApi
        public IQueryable<ServiceType> GetServiceType()
        {
            return db.ServiceType;
        }

        // GET: api/ServiceTypesApi/5
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult GetServiceType(int id)
        {
            ServiceType serviceType = db.ServiceType.Find(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            return Ok(serviceType);
        }

        // PUT: api/ServiceTypesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceType(int id, ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceType.IdServiceType)
            {
                return BadRequest();
            }

            db.Entry(serviceType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ServiceTypesApi
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult PostServiceType(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceType.Add(serviceType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceType.IdServiceType }, serviceType);
        }

        // DELETE: api/ServiceTypesApi/5
        [ResponseType(typeof(ServiceType))]
        public IHttpActionResult DeleteServiceType(int id)
        {
            ServiceType serviceType = db.ServiceType.Find(id);
            if (serviceType == null)
            {
                return NotFound();
            }

            db.ServiceType.Remove(serviceType);
            db.SaveChanges();

            return Ok(serviceType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceTypeExists(int id)
        {
            return db.ServiceType.Count(e => e.IdServiceType == id) > 0;
        }
    }
}