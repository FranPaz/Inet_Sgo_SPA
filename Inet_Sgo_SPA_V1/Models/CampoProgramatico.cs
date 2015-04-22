using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inet_Sgo_SPA_V1.Models
{
    public class CampoProgramatico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Dictamen> Dictamenes { get; set; } //fpaz: Relacion 1 a M con Dictamen (Muchos)

        //fpaz: Relacion 1 a M con TipoCampoProg. (uno)
        public int TipoCampoProgramaticoId { get; set; }
        public virtual TipoCampoProgramatico TipoCampoProgramatico { get; set; }

        public virtual ICollection<TipoLineaInstitucional> TiposLineasInstitucionales { get; set; } //Relacion 1 a M con TipoLineaInstitucional (muchos)
        public virtual ICollection<TipoLineaJurisdiccional> TiposLineasJurisdiccionales { get; set; } //Relacion 1 a M con TipoLineaJurisdiccional (muchos)

        // 1 a M con TipoCampoJurisdiccional (uno)
        public int? TipoCampoJurisdiccionalId { get; set; }
        public virtual TipoCampoJurisdiccional TipoCampoJurisdiccional { get; set; }
    }

    public class TipoCampoProgramatico
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<CampoProgramatico> CamposProgramaticos { get; set; } //fpaz: Relacion 1 a M con CamposProg. (Muchos)
    }
}