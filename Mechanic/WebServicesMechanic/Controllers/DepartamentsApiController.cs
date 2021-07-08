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
    public class DepartamentsApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/DepartamentsApi
        public IQueryable<Departament> GetDepartament()
        {
            return db.Departament;
        }

        // GET: api/DepartamentsApi/5
        [ResponseType(typeof(Departament))]
        public IHttpActionResult GetDepartament(int id)
        {
            Departament departament = db.Departament.Find(id);
            if (departament == null)
            {
                return NotFound();
            }

            return Ok(departament);
        }

        // PUT: api/DepartamentsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDepartament(int id, Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != departament.IdDepartament)
            {
                return BadRequest();
            }

            db.Entry(departament).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentExists(id))
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

        // POST: api/DepartamentsApi
        [ResponseType(typeof(Departament))]
        public IHttpActionResult PostDepartament(Departament departament)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Departament.Add(departament);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = departament.IdDepartament }, departament);
        }

        // DELETE: api/DepartamentsApi/5
        [ResponseType(typeof(Departament))]
        public IHttpActionResult DeleteDepartament(int id)
        {
            Departament departament = db.Departament.Find(id);
            if (departament == null)
            {
                return NotFound();
            }

            db.Departament.Remove(departament);
            db.SaveChanges();

            return Ok(departament);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepartamentExists(int id)
        {
            return db.Departament.Count(e => e.IdDepartament == id) > 0;
        }
    }
}