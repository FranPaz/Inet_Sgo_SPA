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
    public class TipoCargoEncargadoesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoCargoEncargadoes
        public IHttpActionResult GetTipoCargoEncargados()
        {
            try
            {
                var tipoCargosEncargado = db.TipoCargoEncargados.ToList();
                if (tipoCargosEncargado == null)
                {
                    return BadRequest("No existen tipos de Cargos de Encargados");
                }
                else
                {
                    return Ok(tipoCargosEncargado);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        // GET: api/TipoCargoEncargadoes/5
        [ResponseType(typeof(TipoCargoEncargado))]
        public IHttpActionResult GetTipoCargoEncargado(int id)
        {
            TipoCargoEncargado tipoCargoEncargado = db.TipoCargoEncargados.Find(id);
            if (tipoCargoEncargado == null)
            {
                return NotFound();
            }

            return Ok(tipoCargoEncargado);
        }

        // PUT: api/TipoCargoEncargadoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoCargoEncargado(int id, TipoCargoEncargado tipoCargoEncargado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCargoEncargado.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCargoEncargado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCargoEncargadoExists(id))
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

        // POST: api/TipoCargoEncargadoes
        [ResponseType(typeof(TipoCargoEncargado))]
        public IHttpActionResult PostTipoCargoEncargado(TipoCargoEncargado tipoCargoEncargado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoCargoEncargados.Add(tipoCargoEncargado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoCargoEncargado.Id }, tipoCargoEncargado);
        }

        // DELETE: api/TipoCargoEncargadoes/5
        [ResponseType(typeof(TipoCargoEncargado))]
        public IHttpActionResult DeleteTipoCargoEncargado(int id)
        {
            TipoCargoEncargado tipoCargoEncargado = db.TipoCargoEncargados.Find(id);
            if (tipoCargoEncargado == null)
            {
                return NotFound();
            }

            db.TipoCargoEncargados.Remove(tipoCargoEncargado);
            db.SaveChanges();

            return Ok(tipoCargoEncargado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCargoEncargadoExists(int id)
        {
            return db.TipoCargoEncargados.Count(e => e.Id == id) > 0;
        }
    }
}