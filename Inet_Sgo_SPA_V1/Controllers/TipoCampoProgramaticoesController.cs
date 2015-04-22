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
    public class TipoCampoProgramaticoesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoCampoProgramaticoes
        public IHttpActionResult GetTiposCamposProgramaticos()
        {
            var listTiposCamposProg = db.TiposCamposProgramaticos.ToList();

            if (listTiposCamposProg == null)
            {
                return NotFound();
            }
            return Ok(listTiposCamposProg);
        }

        // GET: api/TipoCampoProgramaticoes/5
        [ResponseType(typeof(TipoCampoProgramatico))]
        public IHttpActionResult GetTipoCampoProgramatico(int id)
        {
            TipoCampoProgramatico tipoCampoProgramatico = db.TiposCamposProgramaticos.Find(id);
            if (tipoCampoProgramatico == null)
            {
                return NotFound();
            }

            return Ok(tipoCampoProgramatico);
        }

        // PUT: api/TipoCampoProgramaticoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCampoProgramatico(int id, TipoCampoProgramatico tipoCampoProgramatico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCampoProgramatico.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCampoProgramatico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCampoProgramaticoExists(id))
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

        // POST: api/TipoCampoProgramaticoes
        [ResponseType(typeof(TipoCampoProgramatico))]
        public IHttpActionResult PostTipoCampoProgramatico(TipoCampoProgramatico tipoCampoProgramatico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposCamposProgramaticos.Add(tipoCampoProgramatico);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCampoProgramatico.Id }, tipoCampoProgramatico);
        }

        // DELETE: api/TipoCampoProgramaticoes/5
        [ResponseType(typeof(TipoCampoProgramatico))]
        public IHttpActionResult DeleteTipoCampoProgramatico(int id)
        {
            TipoCampoProgramatico tipoCampoProgramatico = db.TiposCamposProgramaticos.Find(id);
            if (tipoCampoProgramatico == null)
            {
                return NotFound();
            }

            db.TiposCamposProgramaticos.Remove(tipoCampoProgramatico);
            db.SaveChanges();

            return Ok(tipoCampoProgramatico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCampoProgramaticoExists(int id)
        {
            return db.TiposCamposProgramaticos.Count(e => e.Id == id) > 0;
        }
    }
}