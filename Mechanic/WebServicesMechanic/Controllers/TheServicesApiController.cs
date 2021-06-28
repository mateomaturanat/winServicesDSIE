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
    public class TheServicesApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/TheServicesApi
        public IQueryable<TheService> GetTheService()
        {
            return db.TheService;
        }

        // GET: api/TheServicesApi/5
        [ResponseType(typeof(TheService))]
        public IHttpActionResult GetTheService(int id)
        {
            TheService theService = db.TheService.Find(id);
            if (theService == null)
            {
                return NotFound();
            }

            return Ok(theService);
        }

        // PUT: api/TheServicesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTheService(int id, TheService theService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != theService.IdTheService)
            {
                return BadRequest();
            }

            db.Entry(theService).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TheServiceExists(id))
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

        // POST: api/TheServicesApi
        [ResponseType(typeof(TheService))]
        public IHttpActionResult PostTheService(TheService theService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TheService.Add(theService);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = theService.IdTheService }, theService);
        }

        // DELETE: api/TheServicesApi/5
        [ResponseType(typeof(TheService))]
        public IHttpActionResult DeleteTheService(int id)
        {
            TheService theService = db.TheService.Find(id);
            if (theService == null)
            {
                return NotFound();
            }

            db.TheService.Remove(theService);
            db.SaveChanges();

            return Ok(theService);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TheServiceExists(int id)
        {
            return db.TheService.Count(e => e.IdTheService == id) > 0;
        }
    }
}