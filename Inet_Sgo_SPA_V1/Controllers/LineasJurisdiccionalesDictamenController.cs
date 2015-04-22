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
    public class LineasJurisdiccionalesDictamenController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/LineasJurisdiccionalesDictamen
        public IQueryable<LineaJurisdiccionalDictamen> GetLineaJurisdiccionalDictamen()
        {
            return db.LineasJurisdiccionalesDictamen;
        }

        // GET: api/LineasJurisdiccionalesDictamen/5
        [ResponseType(typeof(LineaJurisdiccionalDictamen))]
        public IHttpActionResult GetLineaJurisdiccionalDictamen(int id)
        {
            LineaJurisdiccionalDictamen lineaJurisdiccionalDictamen = db.LineasJurisdiccionalesDictamen.Find(id);
            if (lineaJurisdiccionalDictamen == null)
            {
                return NotFound();
            }

            return Ok(lineaJurisdiccionalDictamen);
        }

        // PUT: api/LineasJurisdiccionalesDictamen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineaJurisdiccionalDictamen(int id, LineaJurisdiccionalDictamen lineaJurisdiccionalDictamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineaJurisdiccionalDictamen.Id)
            {
                return BadRequest();
            }

            db.Entry(lineaJurisdiccionalDictamen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaJurisdiccionalDictamenExists(id))
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

        // POST: api/LineasJurisdiccionalesDictamen
        [ResponseType(typeof(LineaJurisdiccionalDictamen))]
        public IHttpActionResult PostLineaJurisdiccionalDictamen(LineaJurisdiccionalDictamen lineaJurisdiccionalDictamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineasJurisdiccionalesDictamen.Add(lineaJurisdiccionalDictamen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineaJurisdiccionalDictamen.Id }, lineaJurisdiccionalDictamen);
        }

        // DELETE: api/LineasJurisdiccionalesDictamen/5
        [ResponseType(typeof(LineaJurisdiccionalDictamen))]
        public IHttpActionResult DeleteLineaJurisdiccionalDictamen(int id)
        {
            LineaJurisdiccionalDictamen lineaJurisdiccionalDictamen = db.LineasJurisdiccionalesDictamen.Find(id);
            if (lineaJurisdiccionalDictamen == null)
            {
                return NotFound();
            }

            db.LineasJurisdiccionalesDictamen.Remove(lineaJurisdiccionalDictamen);
            db.SaveChanges();

            return Ok(lineaJurisdiccionalDictamen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaJurisdiccionalDictamenExists(int id)
        {
            return db.LineasJurisdiccionalesDictamen.Count(e => e.Id == id) > 0;
        }
    }
}