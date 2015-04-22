using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    // Detalles de Lineas Jurisdiccionales para Dictamenes de Administradores de Redes y Piso Tecnologico

    #region Administradores de Red
    [Table("FondoAdminRed")]
    public class FondoAdminRed : DetalleLineaJuridisccional
    {
        // 1 a M con ServicioAdminRed (muchos)
        public virtual ICollection<ServicioAdminRed> ServiciosAdminRed { get; set; }
    }

    [Table("ServiciosAdminRed")]
    public class ServicioAdminRed
    {
        public int Id { get; set; }
        public decimal MontoMensual { get; set; }
        public decimal HorasMes { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Turno { get; set; }
        
        // 1 a M con Administrador de Red
        public int AdministradorDeRedId { get; set; }
        public virtual AdministradorDeRed AdministradorDeRed { get; set; }

        // 1 a M con FondoAdminRed (uno)
        public int FondoAdminRedId { get; set; }
        public virtual FondoAdminRed FondoAdminRed { get; set; }

    }
    
    [Table("AdministradoresDeRedes")]
    public class AdministradorDeRed : Persona
    {
        public virtual ICollection<ServicioAdminRed> ServicioAdminRed { get; set; } // 1 a M con ServicioAdminRed (muchos)
    }    
    
    #endregion

    #region InstalacionesRed
    [Table("FondoInstalacionRedPiso")]
    public class FondoInstalacionRedPiso : DetalleLineaJuridisccional
    {
        // 1 a M con InstalacionRedPiso (muchos)
        public virtual ICollection<InstalacionRedPiso> InstalacionRedPiso { get; set; }
    }

    [Table("InstalacionRedPiso")]
    public class InstalacionRedPiso //clase que va a tener el detalle general de una linea Instalacion de Red de un dictamen de Instalacion de piso tecnologico y Admin de Redes
    {
        public int Id { get; set; }
        // 1 a M con InstaladorRed (uno)
        public int InstaladorRedId { get; set; }
        public virtual InstaladorRed InstaladorRed { get; set; }

        //1 a M con DetalleInstalacionRed (muchos)
        public virtual ICollection<DetalleInstalacionRed> DetallesInstalacionRed { get; set; }

        // 1 a M con FondoInstalacionRedPiso (uno)
        public int FondoInstalacionRedPisoId { get; set; }
        public virtual FondoInstalacionRedPiso FondoInstalacionRedPiso { get; set; }
    }

    [Table("InstaladorRed")]
    public class InstaladorRed : PrestadorDeServicios
    {
        // 1 a M con InstalacionRedPiso (muchos)
        public virtual ICollection<InstalacionRedPiso> InstalacionesRedPiso { get; set; }
    }

    public class DetalleInstalacionRed
    {
        public int Id { get; set; }
        public string Item { get; set; } //seria la descripcion del equipo o insumo que se instalo
        public int cantidad { get; set; }
        public string unidadMedida { get; set; } //unidad de medida del item del detalle

        //1 a M con InstalacionRedPiso (uno)
        public int InstalacionRedPisoId { get; set; }
        public virtual InstalacionRedPiso InstalacionRedPiso { get; set; }
    }
    #endregion

    #region Servicios de Internet

    [Table("FondoServicioInternet")]
    public class FondoServicioInternet : DetalleLineaJuridisccional
    {
        // 1 a M con ServicioCatering (muchos)
        public virtual ICollection<ServicioInternet> ServicioInternet { get; set; }
    }

    [Table("ServiciosInternet")]
    public class ServicioInternet
    {
        public int Id { get; set; }
        public decimal MontoMensual { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal MontoInstalacion { get; set; }

        // 1 a M con PrestadorInternet (uno)
        public int PrestadorInternetId { get; set; }
        public virtual PrestadorInternet PrestadorInternet { get; set; }

        // 1 a M con FondoServicioInternet (uno)
        public int FondoServicioInternetId { get; set; }
        public virtual FondoServicioInternet FondoServicioInternet { get; set; }
    }

    [Table("PrestadoresInternet")]
    public class PrestadorInternet : PrestadorDeServicios //clase que va a tener los prestadores de servicios de conexion a internet en las escuelas
    {
        // 1 a M con ServicioInternet
        public virtual ICollection<ServicioInternet> ServiciosInternet { get; set; }

    }

    #endregion
}