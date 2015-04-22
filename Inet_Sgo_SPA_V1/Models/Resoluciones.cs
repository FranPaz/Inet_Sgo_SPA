using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    public abstract class Resolucion //Clase Base para las resoluciones INET y Ministerial
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string Expediente { get; set; }       
        public decimal MontoAcreditado { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoCorriente { get; set; }
        public string Observaciones { get; set; }
    }

    #region Resolucion Inet
    [Table("ResolucionesInet")]
    public class ResolucionInet:Resolucion
    {
        public ResolucionInet() {
            //this.DictamenesInstitucionales = new HashSet<DictamenInstitucional>(); // M a M con DictamenInstitucional
            //this.DictamenesJurisdiccionales = new HashSet<DictamenJurisdiccional>(); // M a M conDictamenJurisdiccional
            this.Dictamenes = new HashSet<Dictamen>(); // M a M con Dictamen
        }
        public bool Complementario { get; set; } // para ver si la resolucion es una ampliacion de otra emitida anteriormente
        //public virtual ICollection<DictamenInstitucional> DictamenesInstitucionales { get; set; } // M a M con DictamenInstitucional
        //public virtual ICollection<DictamenJurisdiccional> DictamenesJurisdiccionales { get; set; } // M a M con DictamenJurisdiccional
        public virtual ICollection<Dictamen> Dictamenes { get; set; } // M a M con Dictamenes --> clase abstracta base para dictamenes institucionales y jurisdiccionales
    }
    #endregion

    #region Resolucion Ministerial
    [Table("ResolucionesMinisteriales")]
    public class ResolucionMinisterial:Resolucion
    {
        public ResolucionMinisterial() { }
        public virtual ICollection<Transferencia> Transferencias { get; set; } // 1 a M con ResolucionMinisterial (muchos)
        
    }
    #endregion
}