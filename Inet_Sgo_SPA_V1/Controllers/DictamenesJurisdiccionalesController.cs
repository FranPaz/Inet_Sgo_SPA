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
    public class DictamenesJurisdiccionalesController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/DictamenesJurisdiccionales
        public IHttpActionResult GetDictamen()
        {
            try
            {
                var listDictamenensJuris = db.DictamenesJurisdiccionales.ToList();

                if (listDictamenensJuris == null)
                {
                    return BadRequest("No se encontraron Dictamenes Jurisdiccionales");
                }
                else
                {
                    return Ok(listDictamenensJuris);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        // GET: api/DictamenesJurisdiccionales/5
        [ResponseType(typeof(DictamenJurisdiccional))]
        public IHttpActionResult GetDictamenJurisdiccional(int id)
        {
            DictamenJurisdiccional dictamenJurisdiccional = db.DictamenesJurisdiccionales.Find(id);
            if (dictamenJurisdiccional == null)
            {
                return NotFound();
            }

            return Ok(dictamenJurisdiccional);
        }

        // PUT: api/DictamenesJurisdiccionales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDictamenJurisdiccional(int id, DictamenJurisdiccional dictamenJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dictamenJurisdiccional.Id)
            {
                return BadRequest();
            }

            db.Entry(dictamenJurisdiccional).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DictamenJurisdiccionalExists(id))
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

        // POST: api/DictamenesJurisdiccionales
        [ResponseType(typeof(DictamenJurisdiccional))]
        public IHttpActionResult PostDictamenJurisdiccional(DictamenJurisdiccional dictamenJurisdiccional)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {                
                db.DictamenesJurisdiccionales.Add(dictamenJurisdiccional);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
            
        }

        // DELETE: api/DictamenesJurisdiccionales/5
        [ResponseType(typeof(DictamenJurisdiccional))]
        public IHttpActionResult DeleteDictamenJurisdiccional(int id)
        {
            DictamenJurisdiccional dictamenJurisdiccional = db.DictamenesJurisdiccionales.Find(id);
            if (dictamenJurisdiccional == null)
            {
                return NotFound();
            }

            db.DictamenesJurisdiccionales.Remove(dictamenJurisdiccional);
            db.SaveChanges();

            return Ok(dictamenJurisdiccional);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DictamenJurisdiccionalExists(int id)
        {
            return db.DictamenesJurisdiccionales.Count(e => e.Id == id) > 0;
        }
    }
}