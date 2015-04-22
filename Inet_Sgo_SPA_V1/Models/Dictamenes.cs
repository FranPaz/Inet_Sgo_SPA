using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    // En el modelo se va a usar Table per Type (TPT) para la herencia de clases de BD
    public abstract class Dictamen //clase base de Dictamenes Institucionales y Jurisdiccionales
    {
        public int Id { get; set; }
        [Required]
        public string NroDictamen { get; set; }
        public string NroExpediente { get; set; }
        public string CodPlanMejora { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }
        public string DescripcionInformal { get; set; }
        public bool Complementario { get; set; } // para ver si la resolucion es una ampliacion de otra emitida anteriormente

        //fpaz: Relacion 1 a M con CampoProgramatico (uno)
        public int CampoProgramaticoId { get; set; }
        public virtual CampoProgramatico CampoProgramatico { get; set; }

        public virtual ICollection<ResolucionInet> ResolucionesInet { get; set; } // M a M con ResolucionInet 
    }
    
    [Table("DictamenesInstitucionales")]
    public class DictamenInstitucional:Dictamen
    {
        public DictamenInstitucional() { }
        public string Jurisdiccion { get; set; }

        // 1 a M con Escuelas (uno)
        public int EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }
        public virtual ICollection<LineaInstitucionalDictamen> LineasInstitucionalesDictamen { get; set; } // 1 a M con LineaInstitucionalDictamen (muchos)
        //public virtual ICollection<ResolucionInet> ResolucionesInet { get; set; } // M a M con ResolucionInet 
    }

    [Table("DictamenesJurisdiccionales")]
    public class DictamenJurisdiccional:Dictamen
    {
        public DictamenJurisdiccional() { }        
        public virtual ICollection<LineaJurisdiccionalDictamen> LineasJurisdiccionalesDictamen { get; set; } // 1 a M con LineaJurisdiccionalDictamen (muchos)
        //public virtual ICollection<ResolucionInet> ResolucionesInet { get; set; } // M a M con ResolucionInet
        
    }
}