using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    public abstract class Rendicion
    {        
        public int Id { get; set; }
        public string Expediente { get; set; }
        public DateTime FechaRendido { get; set; }
        public bool CargadoSitrared { get; set; } // para poner V o F si ya se cargo tambien en sitrared o no
    }

    public abstract class DetalleRendicion
    {
        public int Id { get; set; }
        public string NroComprobante { get; set; }
        public DateTime FechaComprobante { get; set; }
        public string DetalleItemRendido { get; set; }
        public string ImporteComprobante { get; set; }
        public decimal MontoCapitalRendido { get; set; }
        public decimal MontoCorrienteRendido { get; set; }        

        //Relacion 1 a M con TipoComprobante
        public int TipoComprobanteId { get; set; }
        public virtual TipoComprobante TipoComprobante { get; set; }

        //Relacion 1 a M con PrestadorDeServicios
        public int PrestadorDeServiciosId { get; set; }
        public virtual PrestadorDeServicios PrestadorDeServicios { get; set; }
    }

    #region Rendiciones Institucionales
    [Table("RendicionInstitucional")]
    public class RendicionInstitucional:Rendicion
    {
        //Relacion 1 a M con TransferenciaInstitucional (uno)
        public int TransferenciaInstitucionalId { get; set; }
        public virtual TransferenciaInstitucional TransferenciaInstitucional { get; set; }
        public virtual ICollection<DetalleRendicionInstitucional> DetallesRendicionesInstitucionales { get; set; } // 1 a M con DetalleRendicionInstitucional (muchos)
    }

    [Table("DetalleRendicionInstitucional")]
    public class DetalleRendicionInstitucional:DetalleRendicion
    {
        //Relacion 1 a M con RendicionInstitucional
        public int RendicionInstitucionalId { get; set; }
        public virtual RendicionInstitucional RendicionInstitucional { get; set; }      
    }
    #endregion

    #region Rendiciones Jurisdiccionales
     [Table("RendicionJurisdiccional")]
    public class RendicionJurisdiccional : Rendicion
    {
        //Relacion 1 a M con TransferenciaInstitucional (uno)
        public int TransferenciaJurisdiccionalId { get; set; }
        public virtual TransferenciaJurisdiccional TransferenciaJurisdiccional { get; set; }
        public virtual ICollection<DetalleRendicionJurisdiccional> DetalleRendicionJurisdiccional { get; set; } //Relacion 1 a M con DetalleRendicionJurisdiccional (muchos)
    }

    [Table("DetalleRendicionJurisdiccional")]
    public class DetalleRendicionJurisdiccional : DetalleRendicion
    {
        //Relacion 1 a M con RendicionJurisdiccional (uno)
        public int RendicionJurisdiccionalId { get; set; }
        public virtual RendicionJurisdiccional RendicionJurisdiccional { get; set; }
    }
    #endregion
}