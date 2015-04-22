using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    // En el modelo se va a usar Table per Type (TPT) para la herencia de clases de BD
    public abstract class TipoLineaAccion //fpaz: sirve de base para definir los tipos de linea de accion que puede tener cada campro programatico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        //Relacion 1 a M con Campo Programatico (uno)
        public int CampoProgramaticoId { get; set; }
        public virtual CampoProgramatico CampoProgramatico { get; set; }
    }

    #region Tipo de Lineas Institucionales
    // fpaz: TipoLineaInstitucional define las lineas de los distintos campos prog Institucionales, ej: campo II, puede tener la linea F05 A, F07, etc
    [Table("TiposLineasInstitucionales")]
    public class TipoLineaInstitucional : TipoLineaAccion
    {
        public virtual ICollection<LineaInstitucionalDictamen> LineasInstitucionalesDictamen { get; set; } //Relacion 1 a M con LineaInstitucionalDictamen (muchos)
    }
    #endregion

    #region Tipo de Lineas Jurisdiccionales
    // fpaz: TipoLineaJurisdiccional define las lineas de los distintos campos prog Jurisdiccionales, ej: campo II, puede tener la linea A, B, C, etc
    // ej: "campo jurisdiccional IV (administradores de Red y piso tec)" tiene lineas jurisdiccionales A, B, D, distintas en descripcion y detalles a las linea A, B, D del Campor Prog Jurisdiccional II (Profesorado ET)
    [Table("TiposLineasJurisdiccionales")]
    public class TipoLineaJurisdiccional:TipoLineaAccion
    {
        public virtual ICollection<LineaJurisdiccionalDictamen> LineasJurisdiccionalesDictamen { get; set; } //Relacion 1 a M con LineaJurisdiccionalDictamen (muchos)
    }    
    #endregion
}