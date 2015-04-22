using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    public class Transferencia
    {
        public int Id { get; set; }
        public decimal MontoImputado { get; set; }
        public string Jurisdiccion { get; set; }
        public string Programa { get; set; }
        public string Actividad { get; set; }
        public string Partida { get; set; }
        public string Financiamiento { get; set; }
        public DateTime FechaTransferencia { get; set; }
        
        // 1 a M con ResolucionMinisterial (uno)
        public int ResolucionMinisterialId { get; set; }
        public virtual ResolucionMinisterial ResolucionMinisterial { get; set; }
        public virtual ICollection<TransferenciaInstitucional> TransferenciasInstitucionales { get; set; } //Relacion 1 a M con TransferenciaInstitucional (muchos)        
        public virtual ICollection<TransferenciaJurisdiccional> TransferenciasJurisdiccionales { get; set; } //Relacion 1 a M con TransferenciaJurisdiccional (muchos)
    }

    #region Transferencia Institucional
    public class TransferenciaInstitucional
    {
        public int Id { get; set; }
        public decimal MontoCapitalTransferido { get; set; }
        public decimal MontoCorrienteTransferido { get; set; }        

        //Relacion 1 a M con LineaInstitucionalDictamen (uno)
        public int LineaInstitucionalDictamenId { get; set; }
        public virtual LineaInstitucionalDictamen LineaInstitucionalDictamen { get; set; }        

        //Relacion 1 a M con Transferencias (uno)
        public int TransferenciaId { get; set; }
        public virtual Transferencia Transferencia { get; set; }
        public virtual ICollection<RendicionInstitucional> RendicionesInstitucionales { get; set; } //Relacion 1 a M con RendicionInstitucional (muchos)
    }
    #endregion

    #region Transferencia Juridisccional
    public class TransferenciaJurisdiccional
    {
        public int Id { get; set; }
        public decimal MontoCapitalTransferido { get; set; }
        public decimal MontoCorrienteTransferido { get; set; }

        //Relacion 1 a M con Transferencias (uno)
        public int TransferenciaId { get; set; }
        public virtual Transferencia Transferencia { get; set; }

        //Relacion 1 a M con Transferencias Jurisdiccionales (uno)
        public int RubroLineaJuridisccionalId { get; set; }
        public virtual DetalleLineaJuridisccional RubroLineaJuridisccional { get; set; }

        public virtual ICollection<RendicionJurisdiccional> RendicionesJurisdiccionales { get; set; } //Relacion 1 a M con RendicionJurisdiccional (muchos)
    }
    #endregion
}