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
using Inet_Sgo_SPA_V1.Models;

namespace Inet_Sgo_SPA_V1.Controllers
{
    public class ResolucionesMinisterialesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/ResolucionesMinisteriales
        public IQueryable<ResolucionMinisterial> GetResolucionMinisterials()
        {
            return db.ResolucionesMinisteriales;
        }

        // GET: api/ResolucionesMinisteriales/5
        [ResponseType(typeof(ResolucionMinisterial))]
        public IHttpActionResult GetResolucionMinisterial(int id)
        {
            ResolucionMinisterial resolucionMinisterial = db.ResolucionesMinisteriales.Find(id);
            if (resolucionMinisterial == null)
            {
                return NotFound();
            }

            return Ok(resolucionMinisterial);
        }

        // PUT: api/ResolucionesMinisteriales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResolucionMinisterial(int id, ResolucionMinisterial resolucionMinisterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resolucionMinisterial.Id)
            {
                return BadRequest();
            }

            db.Entry(resolucionMinisterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResolucionMinisterialExists(id))
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

        // POST: api/ResolucionesMinisteriales
        [ResponseType(typeof(ResolucionMinisterial))]
        public IHttpActionResult PostResolucionMinisterial(ResolucionMinisterial resolucionMinisterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResolucionesMinisteriales.Add(resolucionMinisterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resolucionMinisterial.Id }, resolucionMinisterial);
        }

        // DELETE: api/ResolucionesMinisteriales/5
        [ResponseType(typeof(ResolucionMinisterial))]
        public IHttpActionResult DeleteResolucionMinisterial(int id)
        {
            ResolucionMinisterial resolucionMinisterial = db.ResolucionesMinisteriales.Find(id);
            if (resolucionMinisterial == null)
            {
                return NotFound();
            }

            db.ResolucionesMinisteriales.Remove(resolucionMinisterial);
            db.SaveChanges();

            return Ok(resolucionMinisterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResolucionMinisterialExists(int id)
        {
            return db.ResolucionesMinisteriales.Count(e => e.Id == id) > 0;
        }
    }
}