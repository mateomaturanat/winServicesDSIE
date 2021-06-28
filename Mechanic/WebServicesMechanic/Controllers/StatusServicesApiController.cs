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
    public class StatusServicesApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/StatusServicesApi
        public IQueryable<StatusService> GetStatusService()
        {
            return db.StatusService;
        }

        // GET: api/StatusServicesApi/5
        [ResponseType(typeof(StatusService))]
        public IHttpActionResult GetStatusService(int id)
        {
            StatusService statusService = db.StatusService.Find(id);
            if (statusService == null)
            {
                return NotFound();
            }

            return Ok(statusService);
        }

        // PUT: api/StatusServicesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusService(int id, StatusService statusService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusService.IdStatusService)
            {
                return BadRequest();
            }

            db.Entry(statusService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusServiceExists(id))
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

        // POST: api/StatusServicesApi
        [ResponseType(typeof(StatusService))]
        public IHttpActionResult PostStatusService(StatusService statusService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusService.Add(statusService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusService.IdStatusService }, statusService);
        }

        // DELETE: api/StatusServicesApi/5
        [ResponseType(typeof(StatusService))]
        public IHttpActionResult DeleteStatusService(int id)
        {
            StatusService statusService = db.StatusService.Find(id);
            if (statusService == null)
            {
                return NotFound();
            }

            db.StatusService.Remove(statusService);
            db.SaveChanges();

            return Ok(statusService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusServiceExists(int id)
        {
            return db.StatusService.Count(e => e.IdStatusService == id) > 0;
        }
    }
}