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
    public class DictJurisAdminPisoInternetController : ApiController
    {
        private Inet_Context db = new Inet_Context();

        //// GET: api/DictJurisAdminPisoInternet
        //public IQueryable<DictamenJurisdiccional> GetDictamen()
        //{
        //    return db.Dictamen;
        //}

        //// GET: api/DictJurisAdminPisoInternet/5
        //[ResponseType(typeof(DictamenJurisdiccional))]
        //public IHttpActionResult GetDictamenJurisdiccional(int id)
        //{
        //    DictamenJurisdiccional dictamenJurisdiccional = db.Dictamen.Find(id);
        //    if (dictamenJurisdiccional == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(dictamenJurisdiccional);
        //}

        //// PUT: api/DictJurisAdminPisoInternet/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutDictamenJurisdiccional(int id, DictamenJurisdiccional dictamenJurisdiccional)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != dictamenJurisdiccional.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(dictamenJurisdiccional).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DictamenJurisdiccionalExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //POST: api/DictJurisAdminPisoInternet        
        public IHttpActionResult PostDictamenJurisdiccional(DictAdminPisoInetCustom dictAdminPisoInetCustom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            try
            {
                var dictamenJuris = new DictamenJurisdiccional();
                dictamenJuris = dictAdminPisoInetCustom.dictamenJurisdiccional;

                foreach (var lineaCustom in dictAdminPisoInetCustom.lineasJurisCustom)
                {
                    LineaJurisdiccionalDictamen linea = new LineaJurisdiccionalDictamen();
                    linea = lineaCustom.lineaJurisdiccionalDictamen;
                    

                    if (lineaCustom.fondosAdminRed != null)
                    {
                        foreach (var detalle in lineaCustom.fondosAdminRed)
                        {
                            FondoAdminRed fondoAdmin = new FondoAdminRed();
                            fondoAdmin = detalle;
                            fondoAdmin.ServiciosAdminRed = detalle.ServiciosAdminRed;
                            //fondoAdmin.LineaJurisdiccionalDictamenId = linea.Id;
                            fondoAdmin.LineaJurisdiccionalDictamen = linea;
                            db.FondosAdminRed.Add(fondoAdmin);
                            
                            
                            //detalle.LineaJurisdiccionalDictamenId = linea.Id;                            
                        }                        
                    }

                    if (lineaCustom.fondosInstalacionRedPiso != null)
                    {
                        foreach (var detalle in lineaCustom.fondosInstalacionRedPiso)
                        {
                            detalle.LineaJurisdiccionalDictamenId = linea.Id;
                        }                        
                    }

                    if (lineaCustom.fondosServicioInternet != null)
                    {
                        foreach (var detalle in lineaCustom.fondosServicioInternet)
                        {
                            
                            detalle.LineaJurisdiccionalDictamenId = linea.Id;                            
                        }                        
                    }

                    //linea.DictamenJurisdiccionalId = dictamenJuris.Id;
                    dictamenJuris.LineasJurisdiccionalesDictamen.Add(linea);
     
                }

                db.DictamenesJurisdiccionales.Add(dictamenJuris);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE: api/DictJurisAdminPisoInternet/5
        //[ResponseType(typeof(DictamenJurisdiccional))]
        //public IHttpActionResult DeleteDictamenJurisdiccional(int id)
        //{
        //    DictamenJurisdiccional dictamenJurisdiccional = db.Dictamen.Find(id);
        //    if (dictamenJurisdiccional == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Dictamen.Remove(dictamenJurisdiccional);
        //    db.SaveChanges();

        //    return Ok(dictamenJurisdiccional);
        //}

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

    public class LineaJurisCustom
    {
        public LineaJurisdiccionalDictamen lineaJurisdiccionalDictamen { get; set; }
        public ICollection<FondoAdminRed> fondosAdminRed { get; set; }
        public ICollection<FondoInstalacionRedPiso> fondosInstalacionRedPiso { get; set; }
        public ICollection<FondoServicioInternet> fondosServicioInternet { get; set; }

    }

    public class DictAdminPisoInetCustom
    {
        public DictamenJurisdiccional dictamenJurisdiccional { get; set; }
        public ICollection<LineaJurisCustom> lineasJurisCustom { get; set; }
    }
}