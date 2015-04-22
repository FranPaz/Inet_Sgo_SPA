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
    public class AdministradorDeRedsController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/AdministradorDeReds
        public IHttpActionResult GetAdministradorDeRedes()
        {
            try
            {
                var listaAdminsRedes = db.AdministradorDeRedes.ToList();
                if (listaAdminsRedes == null)
                {
                    return BadRequest("No existen administradores de Red");
                }
                else
                {
                    return Ok(listaAdminsRedes);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            

        }

        // GET: api/AdministradorDeReds/5
        [ResponseType(typeof(AdministradorDeRed))]
        public IHttpActionResult GetAdministradorDeRed(int id)
        {
            AdministradorDeRed administradorDeRed = db.AdministradorDeRedes.Find(id);
            if (administradorDeRed == null)
            {
                return NotFound();
            }

            return Ok(administradorDeRed);
        }

        // PUT: api/AdministradorDeReds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministradorDeRed(int id, AdministradorDeRed administradorDeRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administradorDeRed.Id)
            {
                return BadRequest();
            }

            db.Entry(administradorDeRed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministradorDeRedExists(id))
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

        // POST: api/AdministradorDeReds
        [ResponseType(typeof(AdministradorDeRed))]
        public IHttpActionResult PostAdministradorDeRed(AdministradorDeRed administradorDeRed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdministradorDeRedes.Add(administradorDeRed);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administradorDeRed.Id }, administradorDeRed);
        }

        // DELETE: api/AdministradorDeReds/5
        [ResponseType(typeof(AdministradorDeRed))]
        public IHttpActionResult DeleteAdministradorDeRed(int id)
        {
            AdministradorDeRed administradorDeRed = db.AdministradorDeRedes.Find(id);
            if (administradorDeRed == null)
            {
                return NotFound();
            }

            db.AdministradorDeRedes.Remove(administradorDeRed);
            db.SaveChanges();

            return Ok(administradorDeRed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministradorDeRedExists(int id)
        {
            return db.AdministradorDeRedes.Count(e => e.Id == id) > 0;
        }
    }
}