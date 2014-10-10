using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Inet_Sgo_SPA_V1.Models
{
    public class Escuela
    {
        public int Id { get; set; }
        [Required]
        public string CUE { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }
        public string Localidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }        
        public virtual ICollection<Encargado> Encargados { get; set; } // 1 a M con encargados (muchos)
        public ICollection<DictamenInstitucional> DictamenesInstitucionales { get; set; } // 1 a M con DictamenInstitucional (muchos)
    }

    public class Encargado
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        // 1 a M con Escuelas (uno)
        public int EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }

        // 1 a M con TipoCargoEncargado (uno)
        public int TipoCargoEncargadoId { get; set; }
        public virtual TipoCargoEncargado TipoCargoEncargado { get; set; }

    }

    class TipoCargoEncargado
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Encargado> Encargados { get; set; }
    }
}