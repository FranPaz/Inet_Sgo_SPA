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
    public class TipoComprobantesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoComprobantes
        public IHttpActionResult GetTipoComprobantes()
        {
            var listadoComprobantes = db.TipoComprobantes.ToList();
            if (listadoComprobantes == null)
            {
                return BadRequest("No existen Comprobantes");
            }
            return Ok(listadoComprobantes);
        }

        // GET: api/TipoComprobantes/5
        [ResponseType(typeof(TipoComprobante))]
        public IHttpActionResult GetTipoComprobante(int id)
        {
            TipoComprobante tipoComprobante = db.TipoComprobantes.Find(id);
            if (tipoComprobante == null)
            {
                return NotFound();
            }

            return Ok(tipoComprobante);
        }

        // PUT: api/TipoComprobantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoComprobante(int id, TipoComprobante tipoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoComprobante.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoComprobante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoComprobanteExists(id))
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

        // POST: api/TipoComprobantes
        [ResponseType(typeof(TipoComprobante))]
        public IHttpActionResult PostTipoComprobante(TipoComprobante tipoComprobante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoComprobantes.Add(tipoComprobante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoComprobante.Id }, tipoComprobante);
        }

        // DELETE: api/TipoComprobantes/5
        [ResponseType(typeof(TipoComprobante))]
        public IHttpActionResult DeleteTipoComprobante(int id)
        {
            TipoComprobante tipoComprobante = db.TipoComprobantes.Find(id);
            if (tipoComprobante == null)
            {
                return NotFound();
            }

            db.TipoComprobantes.Remove(tipoComprobante);
            db.SaveChanges();

            return Ok(tipoComprobante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoComprobanteExists(int id)
        {
            return db.TipoComprobantes.Count(e => e.Id == id) > 0;
        }
    }
}