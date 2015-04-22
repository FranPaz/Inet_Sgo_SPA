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
    public class ResolucionesInetController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/ResolucionesInet
        public IQueryable<ResolucionInet> GetResolucionInets()
        {
            return db.ResolucionesInet;
        }

        // GET: api/ResolucionesInet/5
        [ResponseType(typeof(ResolucionInet))]
        public IHttpActionResult GetResolucionInet(int id)
        {
            ResolucionInet resolucionInet = db.ResolucionesInet.Find(id);
            if (resolucionInet == null)
            {
                return NotFound();
            }

            return Ok(resolucionInet);
        }

        // PUT: api/ResolucionesInet/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutResolucionInet(int id, ResolucionInet resolucionInet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resolucionInet.Id)
            {
                return BadRequest();
            }

            db.Entry(resolucionInet).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResolucionInetExists(id))
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

        // POST: api/ResolucionesInet
        [ResponseType(typeof(ResolucionInet))]
        public IHttpActionResult PostResolucionInet(ResolucionInet resolucionInet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ResolucionesInet.Add(resolucionInet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = resolucionInet.Id }, resolucionInet);
        }

        // DELETE: api/ResolucionesInet/5
        [ResponseType(typeof(ResolucionInet))]
        public IHttpActionResult DeleteResolucionInet(int id)
        {
            ResolucionInet resolucionInet = db.ResolucionesInet.Find(id);
            if (resolucionInet == null)
            {
                return NotFound();
            }

            db.ResolucionesInet.Remove(resolucionInet);
            db.SaveChanges();

            return Ok(resolucionInet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ResolucionInetExists(int id)
        {
            return db.ResolucionesInet.Count(e => e.Id == id) > 0;
        }
    }
}