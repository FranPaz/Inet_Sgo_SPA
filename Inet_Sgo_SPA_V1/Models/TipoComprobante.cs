using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inet_Sgo_SPA_V1.Models
{
    public class TipoComprobante
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<DetalleRendicionInstitucional> DetalleRendicionInstitucional { get; set; } // Relacion 1 a M con DetalleRendicionInstitucional
        public virtual ICollection<DetalleRendicionJurisdiccional> DetalleRendicionJurisdiccional { get; set; } // Relacion 1 a M con DetalleRendicionJurisdiccional
    }
}