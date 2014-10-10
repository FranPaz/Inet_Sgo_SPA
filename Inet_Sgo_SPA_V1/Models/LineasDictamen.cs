using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations
using System.ComponentModel.DataAnnotations.Schema;();

namespace Inet_Sgo_SPA_V1.Models
{
    //fpaz: clase base para asociar cada linea de accion aprobada a un dictamen (plan de mejora)
    public abstract class LineaDictamen
    {        
        public int Id { get; set; }
        public decimal MontoAprobado { get; set; }
        public decimal MontoSolicitado { get; set; }
    }

    [Table("LineasJurisdiccionalesDictamen")]
    public class LineaJurisdiccionalDictamen:LineaDictamen
    {
        //Relacion 1 a M con TipoLineaJurisdiccional (uno)
        public int TipoTipoLineaJurisdiccionalId { get; set; }
        public virtual TipoLineaJurisdiccional TipoLineaJurisdiccional { get; set; }
    }

    [Table("LineasInstitucionalesDictamen")]
    public class LineaInstitucionalDictamen : LineaDictamen
    {
        //Relacion 1 a M con TipoLineaInstitucional (uno)
        public int TipoTipoLineaInstitucionalId { get; set; }
        public virtual TipoLineaInstitucional TipoLineaInstitucional { get; set; }
    }

}