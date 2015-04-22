using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    // Detalles para lineas jurisdiccionales de dictamenes jurisdiccionales del Profesorado ET

    #region DocentesPET
    [Table("ModulosDictadosPet")]
    public class ModuloDictadoPet:DetalleLineaJuridisccional //clase con el detalle general de la linea para docentes del PET
    {
        // 1 a M con DetalleModuloDictadoPet (muchos)
        public virtual ICollection<DetalleModuloDictadoPet> DetallesModuloDictadoPet { get; set; }
        public string AñoCohorte { get; set; }        
    }

    public class DetalleModuloDictadoPet
    {
        public int Id { get; set; }
        public decimal HonorariosTotales { get; set; }
        public decimal HonorariosMensuales { get; set; }
        public decimal HorasDictado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // 1 a M con ModuloDictadoPet (uno)
        public int ModuloDictadoPetId { get; set; }
        public virtual ModuloDictadoPet ModuloDictadoPet { get; set; }

        // 1 a M con DocentePet (uno)
        public int DocentePetId { get; set; }
        public virtual DocentePet DocentePet { get; set; }

        // 1 a M con ModuloPet (uno)
        public int ModuloPetId { get; set; }
        public virtual ModuloPet ModuloPet { get; set; }
    }

    [Table("DocentePET")]
    public class DocentePet : Persona
    {
        // 1 a M con DetalleModuloDictadoPet (muchos)
        public virtual ICollection<DetalleModuloDictadoPet> DetallesModulosDictadoPet { get; set; }
    }   

    public class ModuloPet
    {
        public ModuloPet() { }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public virtual ICollection<DetalleModuloDictadoPet> DetallesModulosDictadoPet { get; set; } //Relacion 1 a M con DetalleModuloDictadoPet (muchos)
    }
    #endregion

    #region CoordinadorPet y AuxiliarAdmPet

    [Table("FondosCoordinadorPet")]
    public class FondosCoordinadorPet : DetalleLineaJuridisccional
    {
        // 1 a M con CoordinadorPet (uno)
        public int CoordinadorPetId { get; set; }
        public virtual CoordinadorPet CoordinadorPet { get; set; }
        public decimal HonorariosTotales { get; set; }
        public decimal HonorariosMensuales { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }

    [Table("CoordinadorPet")]
    public class CoordinadorPet : Persona
    {
        //Relacion 1 a M con FondosCoordinadorPet (muchos)
        public ICollection<FondosCoordinadorPet> FondosCoordinadorPet { get; set; }
        
    }

    [Table("FondosAuxiliarPet")]
    public class FondosAuxiliarPet : DetalleLineaJuridisccional
    {        
        public decimal HonorariosTotales { get; set; }
        public decimal HonorariosMensuales { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        // 1 a M con CoordinadorPet (uno)
        public int AuxiliarAdmPetId { get; set; }
        public virtual AuxiliarAdmPet AuxiliarAdmPet { get; set; }
    }

    [Table("AuxiliarAdmPet")]
    public class AuxiliarAdmPet : Persona
    {      
        //Relacion 1 a M con FondosAuxiliarPet (muchos)
        public virtual ICollection<FondosAuxiliarPet> FondosAuxiliaresPet { get; set; }
    }
    #endregion

    #region Estimulo

    [Table("FondosEstimuloPet")]
    public class FondosEstimuloPet:DetalleLineaJuridisccional
    {
        // 1 a M con estimuloAlumno (muchos)
        public virtual ICollection<EstimuloAlumno> EstimulosAlumnos { get; set; }
    }

    [Table("EstimulosAlumnos")]
    public class EstimuloAlumno : Persona
    {
        //Relacion 1 a M entre EstimuloAlumno y ZonaEstimulo (uno)
        public int ZonaEstimuloId { get; set; }
        public virtual ZonaEstimulo ZonaEstimulo { get; set; }

        //Relacion 1 a M con FondosEstimuloPet (uno)
        public int FondosEstimuloPetId { get; set; }
        public virtual FondosEstimuloPet FondosEstimuloPet { get; set; }
    }

    public class ZonaEstimulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal MontoZona { get; set; }
        public virtual ICollection<EstimuloAlumno> EstimulosAlumnos { get; set; } //Relacion 1 a M entre EstimuloAlumno y ZonaEstimulo (muchos)
    }
    #endregion

    #region Catering
    [Table("FondoCatering")]
    public class FondoCatering:DetalleLineaJuridisccional
    {
        // 1 a M con ServicioCatering (muchos)
        public virtual ICollection<ServicioCatering> ServiciosCatering { get; set; }
    }

    public class ServicioCatering
    {
        public int Id { get; set; }
        
        // 1 a M con FondoCatering (uno)
        public int FondoCateringId { get; set; }
        public virtual FondoCatering FondoCatering { get; set; }

        // 1 a M con Prestador Catering (uno)
        public int PrestadorCateringId { get; set; }
        public virtual PrestadorCatering PrestadorCatering { get; set; }

        // 1 a M con DetalleServCatering (uno)
        public int DetalleServCateringId { get; set; }
        public virtual DetalleServCatering DetalleServCatering { get; set; }

    }

    [Table("PrestadoresCatering")]
    public class PrestadorCatering : PrestadorDeServicios
    {
        // 1 a M ServicioCatering (muchos)
        public virtual ICollection<ServicioCatering> ServiciosCatering { get; set; }

    }

    public class DetalleServCatering
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal MontoUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        
        // 1 a M con ServicioCatering (muchos)
        public virtual ICollection<ServicioCatering> ServiciosCatering { get; set; }
    }
    #endregion

    #region Insumos
    [Table("FondoInsumo")]
    public class FondoInsumo : DetalleLineaJuridisccional
    {
        // 1 a M con ServicioCatering (muchos)
        public virtual ICollection<ServicioInsumo> ServiciosInsumo { get; set; }
    }

    public class ServicioInsumo
    {
        public int Id { get; set; }

        // 1 a M con FondoInsumo (uno)
        public int FondoInsumoId { get; set; }
        public virtual FondoInsumo FondoInsumo { get; set; }

        // 1 a M con PrestadorInsumo (uno)
        public int PrestadorInsumoId { get; set; }
        public virtual PrestadorInsumo PrestadorInsumo { get; set; }

        // 1 a M con DetalleServCatering (uno)
        public int DetalleServInsumoId { get; set; }
        public virtual DetalleServInsumo DetalleServInsumo { get; set; }

    }

    [Table("PrestadoresInsumos")]
    public class PrestadorInsumo : PrestadorDeServicios
    {
        // 1 a M con ServicioInsumo
        public virtual ICollection<ServicioInsumo> ServiciosInsumo { get; set; }

    }

    public class DetalleServInsumo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public decimal MontoUnitario { get; set; }
        public decimal MontoTotal { get; set; }

        // 1 a M con ServicioInsumo (muchos)
        public virtual ICollection<ServicioInsumo> ServicioInsumo { get; set; }
    }

    #endregion

}