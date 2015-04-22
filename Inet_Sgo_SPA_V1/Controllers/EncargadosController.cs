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
    public class EncargadosController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/Encargados
        public IHttpActionResult GetEncargadoes(int prmIdEscuela) //devuelve el listado de encargados de una escuela en particular
        {
            var listaEncargados = db.Encargados
                .Where(e => e.EscuelaId == prmIdEscuela) //fpaz: filtro por el id de cliente
                .Include(t => t.TipoCargoEncargado)
                .ToList();
            if (listaEncargados ==  null)
            {
                return BadRequest("No Existen Encargados");
            }

            return Ok(listaEncargados);
        }

        // GET: api/Encargados/5
        [ResponseType(typeof(Encargado))]
        public IHttpActionResult GetEncargado(int prmIdEscuela, int prmIdEncargado) //devuelve la informacion personal de un encargado
        {
            Encargado encargado = db.Encargados.Find(prmIdEncargado);
            if (encargado == null)
            {
                return NotFound();
            }

            return Ok(encargado);            
        }

        // PUT: api/Encargados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEncargado(int id, Encargado encargado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != encargado.Id)
            {
                return BadRequest();
            }

            db.Entry(encargado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncargadoExists(id))
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

        // POST: api/Encargados
        [ResponseType(typeof(Encargado))]
        public IHttpActionResult PostEncargado(Encargado encargado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nuevoEncargado = new Encargado();
                nuevoEncargado = encargado;
                nuevoEncargado.TipoCargoEncargado = db.TipoCargoEncargados.Find(encargado.TipoCargoEncargadoId);
                nuevoEncargado.Escuela = db.Escuelas.Find(encargado.EscuelaId);
                nuevoEncargado.FechaAlta = DateTime.Now;

                db.Encargados.Add(nuevoEncargado);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());                
            }            
        }

        // DELETE: api/Encargados/5
        [ResponseType(typeof(Encargado))]
        public IHttpActionResult DeleteEncargado(int id)
        {
            Encargado encargado = db.Encargados.Find(id);
            if (encargado == null)
            {
                return NotFound();
            }

            db.Encargados.Remove(encargado);
            db.SaveChanges();

            return Ok(encargado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EncargadoExists(int id)
        {
            return db.Encargados.Count(e => e.Id == id) > 0;
        }
    }
}