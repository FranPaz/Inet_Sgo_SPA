using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    // En el modelo se va a usar Table per Type (TPT) para la herencia de clases de BD
    public abstract class Dictamen //clase base
    {
        public int Id { get; set; }
        [Required]
        public string NroDictamen { get; set; }
        public string NroExpediente { get; set; }
        public string CodPlanMejora { get; set; }
        public DateTime Fecha { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }
    }
    
    [Table("DictamenesInstitucionales")]
    public class DictamenInstitucional:Dictamen
    {
        public string Jurisdiccion { get; set; }

        // 1 a M con Escuelas (uno)
        public int EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }
    }

    [Table("DictamenesJurisdiccionales")]
    public class DictamenJurisdiccional:Dictamen
    {
        
    }
}