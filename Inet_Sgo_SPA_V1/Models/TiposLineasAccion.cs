using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    public abstract class TipoLineaAccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }

    [Table("TiposLineasJurisdiccionales")]
    public class TipoLineaJurisdiccional:TipoLineaAccion
    {
        public virtual ICollection<LineaJurisdiccionalDictamen> LineasJurisdiccionalesDictamen { get; set; } //Relacion 1 a M con LineaJurisdiccionalDictamen (muchos)
    }

    [Table("TiposLineasInstitucionales")]
    public class TipoLineaInstitucional:TipoLineaAccion
    {
        public virtual ICollection<LineaInstitucionalDictamen> LineasInstitucionalesDictamen { get; set; } //Relacion 1 a M con LineaInstitucionalDictamen (muchos)
    }
}