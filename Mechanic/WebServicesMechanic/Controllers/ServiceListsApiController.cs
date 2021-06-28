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
    public class ServiceListsApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/ServiceListsApi
        public IQueryable<ServiceList> GetServiceList()
        {
            return db.ServiceList;
        }

        // GET: api/ServiceListsApi/5
        [ResponseType(typeof(ServiceList))]
        public IHttpActionResult GetServiceList(int id)
        {
            ServiceList serviceList = db.ServiceList.Find(id);
            if (serviceList == null)
            {
                return NotFound();
            }

            return Ok(serviceList);
        }

        // PUT: api/ServiceListsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceList(int id, ServiceList serviceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceList.IdServiceList)
            {
                return BadRequest();
            }

            db.Entry(serviceList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceListExists(id))
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

        // POST: api/ServiceListsApi
        [ResponseType(typeof(ServiceList))]
        public IHttpActionResult PostServiceList(ServiceList serviceList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ServiceList.Add(serviceList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceList.IdServiceList }, serviceList);
        }

        // DELETE: api/ServiceListsApi/5
        [ResponseType(typeof(ServiceList))]
        public IHttpActionResult DeleteServiceList(int id)
        {
            ServiceList serviceList = db.ServiceList.Find(id);
            if (serviceList == null)
            {
                return NotFound();
            }

            db.ServiceList.Remove(serviceList);
            db.SaveChanges();

            return Ok(serviceList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceListExists(int id)
        {
            return db.ServiceList.Count(e => e.IdServiceList == id) > 0;
        }
    }
}