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
    public class TypeDocumentsApiController : ApiController
    {
        private ProyectoDelCursoEntities4 db = new ProyectoDelCursoEntities4();

        // GET: api/TypeDocumentsApi
        public IQueryable<TypeDocument> GetTypeDocument()
        {
            return db.TypeDocument;
        }

        // GET: api/TypeDocumentsApi/5
        [ResponseType(typeof(TypeDocument))]
        public IHttpActionResult GetTypeDocument(int id)
        {
            TypeDocument typeDocument = db.TypeDocument.Find(id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            return Ok(typeDocument);
        }

        // PUT: api/TypeDocumentsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypeDocument(int id, TypeDocument typeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typeDocument.IdTypeDocument)
            {
                return BadRequest();
            }

            db.Entry(typeDocument).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeDocumentExists(id))
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

        // POST: api/TypeDocumentsApi
        [ResponseType(typeof(TypeDocument))]
        public IHttpActionResult PostTypeDocument(TypeDocument typeDocument)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypeDocument.Add(typeDocument);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typeDocument.IdTypeDocument }, typeDocument);
        }

        // DELETE: api/TypeDocumentsApi/5
        [ResponseType(typeof(TypeDocument))]
        public IHttpActionResult DeleteTypeDocument(int id)
        {
            TypeDocument typeDocument = db.TypeDocument.Find(id);
            if (typeDocument == null)
            {
                return NotFound();
            }

            db.TypeDocument.Remove(typeDocument);
            db.SaveChanges();

            return Ok(typeDocument);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypeDocumentExists(int id)
        {
            return db.TypeDocument.Count(e => e.IdTypeDocument == id) > 0;
        }
    }
}