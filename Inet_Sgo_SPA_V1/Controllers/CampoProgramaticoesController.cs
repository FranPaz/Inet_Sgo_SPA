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
    public class CampoProgramaticoesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/CampoProgramaticoes
        public IHttpActionResult GetCamposProgramaticos() //devuelve todos los campos programaticos
        {
            try
            {
                var listaCampos = db.CamposProgramaticos
                .Include(t => t.TipoCampoProgramatico)
                .Include(t => t.Dictamenes)
                .ToList();

                if (listaCampos == null)
                {
                    return BadRequest("No Existen Campos Programaticos");
                }
                return Ok(listaCampos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        // GET: api/CampoProgramaticoes/5
        [ResponseType(typeof(CampoProgramatico))]
        public IHttpActionResult GetCampoProgramatico(int id) //devuelve los datos de un campo programatico
        {
            CampoProgramatico campoProgramatico = db.CamposProgramaticos
                .Where(cp => cp.Id == id)
                .Include(t => t.TipoCampoProgramatico)
                .Include(t => t.TipoCampoJurisdiccional)
                .FirstOrDefault();
                
            if (campoProgramatico == null)
            {
                return NotFound();
            }

            return Ok(campoProgramatico);
        }

        public IHttpActionResult GetCampoProgramatico(int id, string prmTipoCampo) //devuelve los datos de campos programaticos dependiendo su tipo, incluyendo tambien sus lineas
        {
            ICollection<CampoProgramatico> listaCampos;

            if (prmTipoCampo == "Campo Institucional")
            {
                listaCampos = db.CamposProgramaticos
                    .Where (c => c.TipoCampoProgramatico.Descripcion == prmTipoCampo)
                    .Include(t => t.TiposLineasInstitucionales)
                    .ToList();
            }
            else
            {
                listaCampos = db.CamposProgramaticos
                    .Where(c => c.TipoCampoProgramatico.Descripcion == prmTipoCampo)
                    .Include(t => t.TiposLineasJurisdiccionales)
                    .Include(t=> t.TipoCampoJurisdiccional)
                    .ToList();
            }            

            if (listaCampos == null)
            {
                return BadRequest("No Existen Campos Programaticos");
            }
            return Ok(listaCampos);
        }

        // PUT: api/CampoProgramaticoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampoProgramatico(int id, CampoProgramatico campoProgramatico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campoProgramatico.Id)
            {
                return BadRequest();
            }

            db.Entry(campoProgramatico).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampoProgramaticoExists(id))
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

        // POST: api/CampoProgramaticoes
        [ResponseType(typeof(CampoProgramatico))]
        public IHttpActionResult PostCampoProgramatico(CampoProgramatico campoProgramatico) // guarda un nuevo Campo Programatico
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.CamposProgramaticos.Add(campoProgramatico);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            

            
        }

        // DELETE: api/CampoProgramaticoes/5
        [ResponseType(typeof(CampoProgramatico))]
        public IHttpActionResult DeleteCampoProgramatico(int id)
        {
            CampoProgramatico campoProgramatico = db.CamposProgramaticos.Find(id);
            if (campoProgramatico == null)
            {
                return NotFound();
            }

            db.CamposProgramaticos.Remove(campoProgramatico);
            db.SaveChanges();

            return Ok(campoProgramatico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampoProgramaticoExists(int id)
        {
            return db.CamposProgramaticos.Count(e => e.Id == id) > 0;
        }
    }
}