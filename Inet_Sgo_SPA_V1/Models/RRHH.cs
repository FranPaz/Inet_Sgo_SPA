using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inet_Sgo_SPA_V1.Models
{
    public abstract class Persona
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string DNI { get; set; }
        public string CUIT { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}