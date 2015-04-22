using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    public abstract class PrestadorDeServicios
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string CUIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public virtual ICollection<DetalleRendicionInstitucional> DetalleRendicion { get; set; } // Relacion 1 a M con DetalleRendicionInstitucional (muchos)
        public ICollection<DetalleRendicionJurisdiccional> DetalleRendicionJurisdiccional { get; set; } // Relacion 1 a M con DetalleRendicionJurisdiccional (muchos)

        // 1 a M con TipoServicioPrestado (uno)
        public int TipoServicioPrestadoId { get; set; }
        public virtual TipoServicioPrestado TipoServicioPrestado { get; set; }
    }

    public class TipoServicioPrestado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        
        // 1 a M con PrestadorDeServicio (muchos)
        public virtual ICollection<PrestadorDeServicios> PrestadoresDeServicios { get; set; }

    }
}