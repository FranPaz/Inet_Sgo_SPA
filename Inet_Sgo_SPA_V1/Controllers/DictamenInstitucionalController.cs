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
    public class DictamenInstitucionalController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/DictamenInstitucional
        public IHttpActionResult GetDictamen() //devuelve todos los dictamenes Institucionales
        {
            var listadoDictamenes = db.DictamenesInstitucionales
                .Include(di => di.CampoProgramatico)
                .Include(di => di.Escuela)
                .Include(di => di.LineasInstitucionalesDictamen)
                .ToList();

            if (listadoDictamenes == null)
            {
                return BadRequest("No existen Dictamenes Cargados");
            }
            return Ok(listadoDictamenes);
        }

        // GET: api/DictamenInstitucional/5
        [ResponseType(typeof(DictamenInstitucional))]
        public IHttpActionResult GetDictamenInstitucional(int id)
        {
            DictamenInstitucional dictamenInstitucional = db.DictamenesInstitucionales.Find(id);
            if (dictamenInstitucional == null)
            {
                return NotFound();
            }

            return Ok(dictamenInstitucional);
        }

        // PUT: api/DictamenInstitucional/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDictamenInstitucional(int id, DictamenInstitucional dictamenInstitucional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dictamenInstitucional.Id)
            {
                return BadRequest();
            }

            db.Entry(dictamenInstitucional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictamenInstitucionalExists(id))
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

        // POST: api/DictamenInstitucional
        [ResponseType(typeof(DictamenInstitucional))]
        public IHttpActionResult PostDictamenInstitucional(DictamenInstitucional dictamenInstitucional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.DictamenesInstitucionales.Add(dictamenInstitucional);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        // DELETE: api/DictamenInstitucional/5
        [ResponseType(typeof(DictamenInstitucional))]
        public IHttpActionResult DeleteDictamenInstitucional(int id)
        {
            DictamenInstitucional dictamenInstitucional = db.DictamenesInstitucionales.Find(id);
            if (dictamenInstitucional == null)
            {
                return NotFound();
            }

            db.DictamenesInstitucionales.Remove(dictamenInstitucional);
            db.SaveChanges();

            return Ok(dictamenInstitucional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DictamenInstitucionalExists(int id)
        {
            return db.DictamenesInstitucionales.Count(e => e.Id == id) > 0;
        }
    }
}