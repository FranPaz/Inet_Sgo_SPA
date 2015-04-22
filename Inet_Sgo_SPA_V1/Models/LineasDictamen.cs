using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    // En el modelo se va a usar Table per Type (TPT) para la herencia de clases de BD
    public abstract class LineaDictamen //fpaz: clase base para asociar cada linea de accion aprobada a un dictamen (plan de mejora)
    {        
        public int Id { get; set; }
        public decimal MontoAprobado { get; set; }
        public decimal MontoSolicitado { get; set; }
    }

    #region Lineas Institucionales
    [Table("LineasInstitucionalesDictamen")]
    public class LineaInstitucionalDictamen : LineaDictamen
    {
        //Relacion 1 a M con TipoLineaInstitucional (uno)
        public int TipoTipoLineaInstitucionalId { get; set; }
        public virtual TipoLineaInstitucional TipoLineaInstitucional { get; set; }
        
        //Relacion 1 a M con DictamenInstitucional (uno)
        public int DictamenInstitucionalId { get; set; }
        public virtual DictamenInstitucional DictamenInstitucional { get; set; }
        public virtual ICollection<TransferenciaInstitucional> TransferenciasInstitucionales { get; set; } //Relacion 1 a M con Transferencias Institucionales (muchos)
    }
    #endregion

    #region Lineas Jurisdiccionales
    [Table("LineasJurisdiccionalesDictamen")]
    public class LineaJurisdiccionalDictamen : LineaDictamen
    {
        //Relacion 1 a M con TipoLineaJurisdiccional (uno)
        public int TipoLineaJurisdiccionalId { get; set; }
        public virtual TipoLineaJurisdiccional TipoLineaJurisdiccional { get; set; }

        //Relacion 1 a M con DictamenJurisdiccional (uno)
        public int DictamenJurisdiccionalId { get; set; }
        public virtual DictamenJurisdiccional DictamenJurisdiccional { get; set; }
        public virtual ICollection<DetalleLineaJuridisccional> DetallesLineasJuridisccional { get; set; } //Relacion 1 a M con DetalleLineaJuridisccional (muchos)
    }

    public abstract class DetalleLineaJuridisccional
    {
        public DetalleLineaJuridisccional() {            
        } 
        public int Id { get; set; }
        public string DescripcionDetallada { get; set; }
        public decimal MontoFinanciado { get; set; }
        public decimal MontoInventariableAprobado { get; set; }
        public decimal MontoNoInventariableAprobado { get; set; }

        //Relacion 1 a M con LineaJurisdiccionalDictamen (uno)
        public int LineaJurisdiccionalDictamenId { get; set; }
        public virtual LineaJurisdiccionalDictamen LineaJurisdiccionalDictamen { get; set; }

        //Relacion 1 a M con Escuelas (uno)
        public int EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; } // 1 a M con Escuelas (uno)
        public virtual ICollection<TransferenciaJurisdiccional> TransferenciasJurisdiccionales { get; set; } //Relacion 1 a M con Transferencias Jurisdiccionales (muchos)                

        //Relacion 1 a M con TiposDetallesJurisdiccionales (uno)
        public int TipoDetalleJurisdiccionalId { get; set; }
        public virtual TipoDetalleJurisdiccional TipoDetalleJurisdiccional { get; set; }
    }

    // fpaz: TipoDetalleJurisdiccional define el tipo de detalle que se puede cargar en cada detalle de linea jurisdiccional
    // ej: "campo jurisdiccional IV (administradores de Red y piso tec)" tiene linea B donde el detalle es siempre de "Servicios de Internet"
    public class TipoDetalleJurisdiccional
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Relacion 1 a M con DetalleLineaJuridisccional (muchos)        
        public virtual ICollection<DetalleLineaJuridisccional> DetallesLineasJuridisccionales { get; set; }

        // Relacion 1 a M con TipoCampoProgramatico (uno)
        public int TipoCampoJurisdiccionalId { get; set; }

        public virtual TipoCampoJurisdiccional TipoCampoJurisdiccional { get; set; }
    }
    #endregion

}