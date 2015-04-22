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
    public class EscuelasController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/Escuelas
        public IHttpActionResult GetEscuelas() // fpaz: devuelve el listado de todas las escuelas
        {
            try
            {
                var listadoEscuelas = db.Escuelas.ToList();
                if (listadoEscuelas == null)
                {
                    return BadRequest("No existen Escuelas Cargadas");
                }
                return Ok(listadoEscuelas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        // GET: api/Escuelas/5
        [ResponseType(typeof(Escuela))]
        public IHttpActionResult GetEscuela(int id)
        {
            Escuela escuela = db.Escuelas.Find(id);
            if (escuela == null)
            {
                return NotFound();
            }

            return Ok(escuela);
        }

        // PUT: api/Escuelas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEscuela(int id, Escuela escuela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != escuela.Id)
            {
                return BadRequest();
            }

            db.Entry(escuela).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!EscuelaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(ex.Message.ToString());
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Escuelas
        [ResponseType(typeof(Escuela))]
        public IHttpActionResult PostEscuela(Escuela escuela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                escuela.FechaAlta = DateTime.Now;
                db.Escuelas.Add(escuela);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE: api/Escuelas/5
        [ResponseType(typeof(Escuela))]
        public IHttpActionResult DeleteEscuela(int id)
        {
            Escuela escuela = db.Escuelas.Find(id);
            if (escuela == null)
            {
                return NotFound();
            }

            db.Escuelas.Remove(escuela);
            db.SaveChanges();

            return Ok(escuela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EscuelaExists(int id)
        {
            return db.Escuelas.Count(e => e.Id == id) > 0;
        }
    }
}