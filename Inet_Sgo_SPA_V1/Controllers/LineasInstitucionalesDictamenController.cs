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
    public class LineasInstitucionalesDictamenController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        // GET: api/LineasInstitucionalesDictamen
        public IQueryable<LineaInstitucionalDictamen> GetLineaInstitucionalDictamen()
        {
            return db.LineasInstitucionalesDictamen;
        }

        // GET: api/LineasInstitucionalesDictamen/5
        [ResponseType(typeof(LineaInstitucionalDictamen))]
        public IHttpActionResult GetLineaInstitucionalDictamen(int id)
        {
            LineaInstitucionalDictamen lineaInstitucionalDictamen = db.LineasInstitucionalesDictamen.Find(id);
            if (lineaInstitucionalDictamen == null)
            {
                return NotFound();
            }

            return Ok(lineaInstitucionalDictamen);
        }

        // PUT: api/LineasInstitucionalesDictamen/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLineaInstitucionalDictamen(int id, LineaInstitucionalDictamen lineaInstitucionalDictamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lineaInstitucionalDictamen.Id)
            {
                return BadRequest();
            }

            db.Entry(lineaInstitucionalDictamen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LineaInstitucionalDictamenExists(id))
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

        // POST: api/LineasInstitucionalesDictamen
        [ResponseType(typeof(LineaInstitucionalDictamen))]
        public IHttpActionResult PostLineaInstitucionalDictamen(LineaInstitucionalDictamen lineaInstitucionalDictamen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LineasInstitucionalesDictamen.Add(lineaInstitucionalDictamen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lineaInstitucionalDictamen.Id }, lineaInstitucionalDictamen);
        }

        // DELETE: api/LineasInstitucionalesDictamen/5
        [ResponseType(typeof(LineaInstitucionalDictamen))]
        public IHttpActionResult DeleteLineaInstitucionalDictamen(int id)
        {
            LineaInstitucionalDictamen lineaInstitucionalDictamen = db.LineasInstitucionalesDictamen.Find(id);
            if (lineaInstitucionalDictamen == null)
            {
                return NotFound();
            }

            db.LineasInstitucionalesDictamen.Remove(lineaInstitucionalDictamen);
            db.SaveChanges();

            return Ok(lineaInstitucionalDictamen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LineaInstitucionalDictamenExists(int id)
        {
            return db.LineasInstitucionalesDictamen.Count(e => e.Id == id) > 0;
        }
    }
}