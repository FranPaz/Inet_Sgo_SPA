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
    public class TipoLineasInstitucionalesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoLineasInstitucionales
        public IHttpActionResult GetTipoLineaInstitucionals()
        {
            var tlInst = db.TipoLineasInstitucionales
                .Include(t => t.CampoProgramatico)
                .ToString();
            if (tlInst == null)
            {
                return BadRequest("No Existen Lineas de Accion Institucionales");
            }
            return Ok(tlInst);            
        }

        // GET: api/TipoLineasInstitucionales/5
        [ResponseType(typeof(TipoLineaInstitucional))]
        public IHttpActionResult GetTipoLineaInstitucional(int prmIdCampoProg) // trae todos los tipos de lineas institucionales que perteneces a un campo programatico
        {
            var listaLineas = db.TipoLineasInstitucionales
                .Where(l => l.CampoProgramaticoId == prmIdCampoProg) //fpaz: filtro por el id del campo programatico                
                //.Include(t => t.CampoProgramatico)
                .ToList();
            if (listaLineas == null)
            {
                return BadRequest("No Lineas de Accion para el Campo Seleccionado");
            }

            return Ok(listaLineas);
        }

        public IHttpActionResult GetTipoLineaInstitucional(int prmIdCampoProg, int prmIdLinea) // devuelve la informacion de una linea institucional en particular
        {
            var infoLinea = db.TipoLineasInstitucionales.Find(prmIdLinea);
                
            if (infoLinea == null)
            {
                return BadRequest("Error al traer los datos de la  Linea de Accion");
            }

            return Ok(infoLinea);
        }

        // PUT: api/TipoLineasInstitucionales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoLineaInstitucional(int id, TipoLineaInstitucional tipoLineaInstitucional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoLineaInstitucional.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoLineaInstitucional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLineaInstitucionalExists(id))
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

        // POST: api/TipoLineasInstitucionales
        [ResponseType(typeof(TipoLineaInstitucional))]
        public IHttpActionResult PostTipoLineaInstitucional(TipoLineaInstitucional tipoLineaInstitucional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nuevaLinea = new TipoLineaInstitucional();
                nuevaLinea = tipoLineaInstitucional;
                //nuevaLinea.CampoProgramatico = db.CamposProgramaticos.Find(tipoLineaInstitucional.CampoProgramaticoId);
                
                db.TipoLineasInstitucionales.Add(nuevaLinea);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        // DELETE: api/TipoLineasInstitucionales/5
        [ResponseType(typeof(TipoLineaInstitucional))]
        public IHttpActionResult DeleteTipoLineaInstitucional(int id)
        {
            TipoLineaInstitucional tipoLineaInstitucional = db.TipoLineasInstitucionales.Find(id);
            if (tipoLineaInstitucional == null)
            {
                return NotFound();
            }

            db.TipoLineasInstitucionales.Remove(tipoLineaInstitucional);
            db.SaveChanges();

            return Ok(tipoLineaInstitucional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoLineaInstitucionalExists(int id)
        {
            return db.TipoLineasInstitucionales.Count(e => e.Id == id) > 0;
        }
    }
}