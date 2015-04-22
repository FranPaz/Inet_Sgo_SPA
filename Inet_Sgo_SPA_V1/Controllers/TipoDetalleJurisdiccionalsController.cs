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
    public class TipoDetalleJurisdiccionalsController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoDetalleJurisdiccionals
        public IHttpActionResult GetTiposDetallesJurisdiccionales() //devuelve todos los tipos de detalles jurisdiccionales
        {
            try
            {
                var listDetalles = db.TiposDetallesJurisdiccionales.ToList();
                if (listDetalles == null)
                {
                    return BadRequest("No existen tipos de detalles jurisdiccionales");
                }
                else
                {
                    return Ok(listDetalles);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET: api/TipoDetalleJurisdiccionals/5
        [ResponseType(typeof(TipoDetalleJurisdiccional))]
        public IHttpActionResult GetTipoDetalleJurisdiccional(int id) // devuelve los tipos de datalles dependiendo del tipo de campo programatico elegido
        {
            var listaTipoDetalleJurisdiccional = db.TiposDetallesJurisdiccionales
                .Where(td => td.TipoCampoJurisdiccionalId == id)
                //.Include(td => td.TipoCampoJurisdiccional)
                .ToList();

            if (listaTipoDetalleJurisdiccional == null)
            {
                return NotFound();
            }

            return Ok(listaTipoDetalleJurisdiccional);
        }

        // PUT: api/TipoDetalleJurisdiccionals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDetalleJurisdiccional(int id, TipoDetalleJurisdiccional tipoDetalleJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDetalleJurisdiccional.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoDetalleJurisdiccional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDetalleJurisdiccionalExists(id))
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

        // POST: api/TipoDetalleJurisdiccionals
        [ResponseType(typeof(TipoDetalleJurisdiccional))]
        public IHttpActionResult PostTipoDetalleJurisdiccional(TipoDetalleJurisdiccional tipoDetalleJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposDetallesJurisdiccionales.Add(tipoDetalleJurisdiccional);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDetalleJurisdiccional.Id }, tipoDetalleJurisdiccional);
        }

        // DELETE: api/TipoDetalleJurisdiccionals/5
        [ResponseType(typeof(TipoDetalleJurisdiccional))]
        public IHttpActionResult DeleteTipoDetalleJurisdiccional(int id)
        {
            TipoDetalleJurisdiccional tipoDetalleJurisdiccional = db.TiposDetallesJurisdiccionales.Find(id);
            if (tipoDetalleJurisdiccional == null)
            {
                return NotFound();
            }

            db.TiposDetallesJurisdiccionales.Remove(tipoDetalleJurisdiccional);
            db.SaveChanges();

            return Ok(tipoDetalleJurisdiccional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDetalleJurisdiccionalExists(int id)
        {
            return db.TiposDetallesJurisdiccionales.Count(e => e.Id == id) > 0;
        }
    }
}