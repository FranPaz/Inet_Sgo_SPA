using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inet_Sgo_SPA_V1.Models
{
    public class TipoCampoJurisdiccional
    {
        public int Id { get; set; }
        public string DescripcionTipo { get; set; }
        public virtual ICollection<CampoProgramatico> CamposProgramaticos { get; set; } // 1 a M con CampoProgramatico (muchos)
        public virtual ICollection<TipoDetalleJurisdiccional> TiposDetallesJurisdiccionales { get; set; } //Relacion 1 a M con TipoDetalleJurisdiccional (muchos)
    }
}