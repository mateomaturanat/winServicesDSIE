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
    public class MechanicsController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/Mechanics
        public IQueryable<Mechanic> GetMechanic()
        {
            return db.Mechanic;
        }

        // GET: api/Mechanics/5
        [ResponseType(typeof(Mechanic))]
        public IHttpActionResult GetMechanic(int id)
        {
            Mechanic mechanic = db.Mechanic.Find(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            return Ok(mechanic);
        }

        // PUT: api/Mechanics/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMechanic(int id, Mechanic mechanic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanic.IdMechanic)
            {
                return BadRequest();
            }

            db.Entry(mechanic).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicExists(id))
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

        // POST: api/Mechanics
        [ResponseType(typeof(Mechanic))]
        public IHttpActionResult PostMechanic(Mechanic mechanic)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Mechanic.Add(mechanic);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanic.IdMechanic }, mechanic);
        }

        // DELETE: api/Mechanics/5
        [ResponseType(typeof(Mechanic))]
        public IHttpActionResult DeleteMechanic(int id)
        {
            Mechanic mechanic = db.Mechanic.Find(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            db.Mechanic.Remove(mechanic);
            db.SaveChanges();

            return Ok(mechanic);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MechanicExists(int id)
        {
            return db.Mechanic.Count(e => e.IdMechanic == id) > 0;
        }
    }
}