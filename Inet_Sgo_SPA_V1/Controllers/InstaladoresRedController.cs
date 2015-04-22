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
    public class InstaladoresRedController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/InstaladoresRed
        public IHttpActionResult GetInstaladorRed()
        {
            try
            {
                var instaladores = db.InstaladoresRed.ToList();
                if (instaladores == null)
                {
                    return BadRequest("No existen instaladores de red y piso tecnologico");
                }
                else
                {
                    return Ok(instaladores);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET: api/InstaladoresRed/5
        [ResponseType(typeof(InstaladorRed))]
        public IHttpActionResult GetInstaladorRed(int id)
        {
            InstaladorRed instaladorRed = db.InstaladoresRed.Find(id);
            if (instaladorRed == null)
            {
                return NotFound();
            }

            return Ok(instaladorRed);
        }

        // PUT: api/InstaladoresRed/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstaladorRed(int id, InstaladorRed instaladorRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instaladorRed.Id)
            {
                return BadRequest();
            }

            db.Entry(instaladorRed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstaladorRedExists(id))
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

        // POST: api/InstaladoresRed
        [ResponseType(typeof(InstaladorRed))]
        public IHttpActionResult PostInstaladorRed(InstaladorRed instaladorRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrestadorDeServicios.Add(instaladorRed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instaladorRed.Id }, instaladorRed);
        }

        // DELETE: api/InstaladoresRed/5
        [ResponseType(typeof(InstaladorRed))]
        public IHttpActionResult DeleteInstaladorRed(int id)
        {
            InstaladorRed instaladorRed = db.InstaladoresRed.Find(id);
            if (instaladorRed == null)
            {
                return NotFound();
            }

            db.PrestadorDeServicios.Remove(instaladorRed);
            db.SaveChanges();

            return Ok(instaladorRed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstaladorRedExists(int id)
        {
            return db.PrestadorDeServicios.Count(e => e.Id == id) > 0;
        }
    }
}