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
    public class TipoCampoJurisdiccionalsController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoCampoJurisdiccionals
        public IHttpActionResult GetTiposCamposJurisdiccionales()
        {
            try
            {
                var listTiposCamposJuris = db.TiposCamposJurisdiccionales.ToList();
                if (listTiposCamposJuris == null)
                {
                    return BadRequest("No existen Tipos de Campos Jurisdiccionales");
                }
                else
                {
                    return Ok(listTiposCamposJuris);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // GET: api/TipoCampoJurisdiccionals/5
        [ResponseType(typeof(TipoCampoJurisdiccional))]
        public IHttpActionResult GetTipoCampoJurisdiccional(int id)
        {
            TipoCampoJurisdiccional tipoCampoJurisdiccional = db.TiposCamposJurisdiccionales.Find(id);
            if (tipoCampoJurisdiccional == null)
            {
                return NotFound();
            }

            return Ok(tipoCampoJurisdiccional);
        }

        // PUT: api/TipoCampoJurisdiccionals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCampoJurisdiccional(int id, TipoCampoJurisdiccional tipoCampoJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCampoJurisdiccional.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCampoJurisdiccional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCampoJurisdiccionalExists(id))
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

        // POST: api/TipoCampoJurisdiccionals
        [ResponseType(typeof(TipoCampoJurisdiccional))]
        public IHttpActionResult PostTipoCampoJurisdiccional(TipoCampoJurisdiccional tipoCampoJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TiposCamposJurisdiccionales.Add(tipoCampoJurisdiccional);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCampoJurisdiccional.Id }, tipoCampoJurisdiccional);
        }

        // DELETE: api/TipoCampoJurisdiccionals/5
        [ResponseType(typeof(TipoCampoJurisdiccional))]
        public IHttpActionResult DeleteTipoCampoJurisdiccional(int id)
        {
            TipoCampoJurisdiccional tipoCampoJurisdiccional = db.TiposCamposJurisdiccionales.Find(id);
            if (tipoCampoJurisdiccional == null)
            {
                return NotFound();
            }

            db.TiposCamposJurisdiccionales.Remove(tipoCampoJurisdiccional);
            db.SaveChanges();

            return Ok(tipoCampoJurisdiccional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCampoJurisdiccionalExists(int id)
        {
            return db.TiposCamposJurisdiccionales.Count(e => e.Id == id) > 0;
        }
    }
}