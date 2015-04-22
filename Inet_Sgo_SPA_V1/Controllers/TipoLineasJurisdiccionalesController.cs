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
    public class TipoLineasJurisdiccionalesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/TipoLineasJurisdiccionales
        public IHttpActionResult GetTipoLineaJurisdiccionals()
        {
            var tlJurisdic = db.TipoLineasJurisdiccionales
                .Include(t => t.CampoProgramatico)
                .ToString();
            if (tlJurisdic == null)
            {
                return BadRequest("No Existen Lineas de Accion Jurisdiccionales");
            }
            return Ok(tlJurisdic);            
        }

        // GET: api/TipoLineasJurisdiccionales/5
        [ResponseType(typeof(TipoLineaJurisdiccional))]
        public IHttpActionResult GetTipoLineaJurisdiccional(int prmIdCampoProg) // trae todos los tipos de lineas institucionales que perteneces a un campo programatico
        {
            var listaLineas = db.TipoLineasJurisdiccionales
                .Where(l => l.CampoProgramaticoId == prmIdCampoProg) //fpaz: filtro por el id del campo programatico                
                //.Include(t => t.CampoProgramatico)
                .ToList();
            if (listaLineas == null)
            {
                return BadRequest("No Lineas de Accion para el Campo Seleccionado");
            }

            return Ok(listaLineas);
        }

        public IHttpActionResult GetTipoLineaJurisdiccional(int prmIdCampoProg, int prmIdLinea) // devuelve la informacion de una linea institucional en particular
        {
            var infoLinea = db.TipoLineasJurisdiccionales.Find(prmIdLinea);

            if (infoLinea == null)
            {
                return BadRequest("Error al traer los datos de la  Linea de Accion");
            }

            return Ok(infoLinea);
        }
        

        // PUT: api/TipoLineasJurisdiccionales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoLineaJurisdiccional(int id, TipoLineaJurisdiccional tipoLineaJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoLineaJurisdiccional.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoLineaJurisdiccional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoLineaJurisdiccionalExists(id))
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

        // POST: api/TipoLineasJurisdiccionales
        [ResponseType(typeof(TipoLineaJurisdiccional))]
        public IHttpActionResult PostTipoLineaJurisdiccional(TipoLineaJurisdiccional tipoLineaJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var nuevaLinea = new TipoLineaJurisdiccional();
                nuevaLinea = tipoLineaJurisdiccional;
                //nuevaLinea.CampoProgramatico = db.CamposProgramaticos.Find(tipoLineaInstitucional.CampoProgramaticoId);

                db.TipoLineasJurisdiccionales.Add(nuevaLinea);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }  
        }

        // DELETE: api/TipoLineasJurisdiccionales/5
        [ResponseType(typeof(TipoLineaJurisdiccional))]
        public IHttpActionResult DeleteTipoLineaJurisdiccional(int id)
        {
            TipoLineaJurisdiccional tipoLineaJurisdiccional = db.TipoLineasJurisdiccionales.Find(id);
            if (tipoLineaJurisdiccional == null)
            {
                return NotFound();
            }

            db.TipoLineasJurisdiccionales.Remove(tipoLineaJurisdiccional);
            db.SaveChanges();

            return Ok(tipoLineaJurisdiccional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoLineaJurisdiccionalExists(int id)
        {
            return db.TipoLineasJurisdiccionales.Count(e => e.Id == id) > 0;
        }
    }
}