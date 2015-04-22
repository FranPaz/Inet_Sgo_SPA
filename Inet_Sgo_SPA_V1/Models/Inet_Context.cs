using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Inet_Sgo_SPA_V1.Models
{
    public class Inet_Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Inet_Context() : base("name=Inet_Context")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer<Inet_Context>(new InetDbInitialier());
        }

        #region definicion de tablas dbset
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.Encargado> Encargados { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.Escuela> Escuelas { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoCargoEncargado> TipoCargoEncargados { get; set; }        

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.CampoProgramatico> CamposProgramaticos { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.AdministradorDeRed> AdministradorDeRedes { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.InstalacionRedPiso> InstalacionRedes { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.InstaladorRed> InstaladoresRed { get; set; }        
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.PrestadorInternet> PrestadoresInternet { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DictamenJurisdiccional> DictamenesJurisdiccionales { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DictamenInstitucional> DictamenesInstitucionales { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.LineaInstitucionalDictamen> LineasInstitucionalesDictamen { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.LineaJurisdiccionalDictamen> LineasJurisdiccionalesDictamen { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DetalleLineaJuridisccional> DetalleLineaJuridisccional { get; set; }        

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DocentePet> DocentesPet { get; set; }        

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.ModuloPet> ModulosPet { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.CoordinadorPet> CoordinadoresPet { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.AuxiliarAdmPet> AuxiliaresAdmPets { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.EstimuloAlumno> EstimulosAlumnos { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.ZonaEstimulo> ZonaEstimuloes { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.PrestadorCatering> PrestadoresCatering { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.RendicionInstitucional> RendicionesInstitucionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TransferenciaInstitucional> TransferenciaInstitucionals { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DetalleRendicionInstitucional> DetalleRendicionesInstitucionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.PrestadorDeServicios> PrestadorDeServicios { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoComprobante> TipoComprobantes { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.RendicionJurisdiccional> RendicionesJurisdiccionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TransferenciaJurisdiccional> TransferenciaJurisdiccionals { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.DetalleRendicionJurisdiccional> DetalleRendicionesJurisdiccionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.ResolucionInet> ResolucionesInet { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.ResolucionMinisterial> ResolucionesMinisteriales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoLineaJurisdiccional> TipoLineasJurisdiccionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoLineaInstitucional> TipoLineasInstitucionales { get; set; }

        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.Transferencia> Transferencias { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoCampoProgramatico> TiposCamposProgramaticos { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoCampoJurisdiccional> TiposCamposJurisdiccionales { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoServicioPrestado> TiposServiciosPrestados { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.TipoDetalleJurisdiccional> TiposDetallesJurisdiccionales { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondoAdminRed> FondosAdminRed { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondoCatering> FondosCatering { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondoInstalacionRedPiso> FondosInstalacionRedPiso { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondoInsumo> FondosInsumo { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondosAuxiliarPet> FondosAuxiliarPet { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondosCoordinadorPet> FondosCoordinadorPet { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondoServicioInternet> FondosServicioInternet { get; set; }
        public System.Data.Entity.DbSet<Inet_Sgo_SPA_V1.Models.FondosEstimuloPet> FondosEstimuloPet { get; set; }

        #endregion
    }

    public class InetDbInitialier:DropCreateDatabaseIfModelChanges<Inet_Context>
    {
        protected override void Seed(Inet_Context context)
        {
            // fpaz: semilla para el llenado automatico de la BD

            #region Semilla de tipo de cargos de encargados
            var tiposCargos = new List<TipoCargoEncargado>
                {
                    new TipoCargoEncargado {Descripcion="Rector"},
                    new TipoCargoEncargado {Descripcion="ViceRector"},
                    new TipoCargoEncargado {Descripcion="Profesor"},
                    new TipoCargoEncargado {Descripcion="Otro"}
                };
            foreach (var item in tiposCargos)
            {
                context.TipoCargoEncargados.Add(item);
            }
            #endregion

            #region Semilla de los tipos de campos programaticos
            var tiposCamposProg = new List<TipoCampoProgramatico>
                {
                    new TipoCampoProgramatico {Descripcion="Campo Institucional"},
                    new TipoCampoProgramatico {Descripcion="Campo Jurisdiccional"}                    
                };
            foreach (var item in tiposCamposProg)
            {
                context.TiposCamposProgramaticos.Add(item);
            }
            #endregion

            #region Semilla de los tipos de comprobantes
            var tiposComprobantes = new List<TipoComprobante>
                {
                    new TipoComprobante {Descripcion="Factura B"},
                    new TipoComprobante {Descripcion="Factura C"},
                    new TipoComprobante {Descripcion="Recibo"},
                    new TipoComprobante {Descripcion="Remito"},
                    new TipoComprobante {Descripcion="Ticket Fiscal"}
                };
            foreach (var item in tiposComprobantes)
            {
                context.TipoComprobantes.Add(item);
            }
            #endregion            

            #region Semilla de los tipos de Servicios Prestados por los prestadores de servicios
            //var tiposServicios = new List<TipoServicioPrestado>
            //    {
            //        new TipoServicioPrestado { Descripcion="Servicio de Catering"},
            //        new TipoServicioPrestado { Descripcion="Servicio de Insumos"},
            //        new TipoServicioPrestado { Descripcion="Servicio de Internet"},
            //        new TipoServicioPrestado { Descripcion="Servicio de Instalacion de Red"},
            //        new TipoServicioPrestado { Descripcion="Otros Servicios"}
            //    };
            //foreach (var item in tiposServicios)
            //{
            //    context.TiposServiciosPrestados.Add(item);
            //}
            #endregion

            #region Semilla de los tipos de Campos Jurisdiccionales y Tipos de Detalles Jurisdiccionales
            var tiposCamposJuris = new List<TipoCampoJurisdiccional>
                {
                    new TipoCampoJurisdiccional { DescripcionTipo="Campo Jurisdiccional General"},

                    new TipoCampoJurisdiccional { DescripcionTipo=" Campo Jurisdiccional Administradores de Red y Piso Tecnologico",
                     TiposDetallesJurisdiccionales = new List<TipoDetalleJurisdiccional>{
                         new TipoDetalleJurisdiccional { Descripcion="Servicio de Administrador de Red"},
                         new TipoDetalleJurisdiccional { Descripcion="Servicio de Instalacion de Piso Tecnologico"},
                         new TipoDetalleJurisdiccional { Descripcion="Servicio de Internet"}
                     }                
                    },

                    new TipoCampoJurisdiccional { DescripcionTipo="Campo Jurisdiccional Profesorado Educacion Tecnica",
                    TiposDetallesJurisdiccionales = new List<TipoDetalleJurisdiccional>{
                            new TipoDetalleJurisdiccional { Descripcion="Modulos Dictados Profesorado E.T"},
                            new TipoDetalleJurisdiccional { Descripcion="Coordinadores Profesorado E.T"},
                            new TipoDetalleJurisdiccional { Descripcion="Auxiliares Administrativos Profesorado E.T"},
                            new TipoDetalleJurisdiccional { Descripcion="Estimulos Profesorado E.T"},
                            new TipoDetalleJurisdiccional { Descripcion="Insumos Profesorado E.T"},
                            new TipoDetalleJurisdiccional { Descripcion="Catering Profesorado E.T"},
                     }                
                    },
                };
            foreach (var item in tiposCamposJuris)
            {
                context.TiposCamposJurisdiccionales.Add(item);
            }
            #endregion

            #region Semilla de los Instaladores de Redes
            
            var instaladores  = new List<InstaladorRed>
                {
                    new InstaladorRed { CUIT="11111", Direccion="calle 1111", Email="a@o.com", RazonSocial="Instalador 1", Telefono="1111" },
                    new InstaladorRed { CUIT="22222", Direccion="calle 2222", Email="a2@2o.com", RazonSocial="Instalador 2", Telefono="2222" },
                    new InstaladorRed { CUIT="33333", Direccion="calle 3333", Email="a3@3o.com", RazonSocial="Instalador 3", Telefono="3333" }                    
                };

            var tipoServicioPrestadotipoServicioPrestadoInstalador = new TipoServicioPrestado { Descripcion = "Servicio de Instalacion de Red" };

            foreach (var item in instaladores)
            {
                item.TipoServicioPrestado =tipoServicioPrestadotipoServicioPrestadoInstalador;
                context.InstaladoresRed.Add(item);
            }
            #endregion

            #region Semilla de los Prestadores de Internet
            var prestadoresInternet = new List<PrestadorInternet>
                {
                    new PrestadorInternet { CUIT="11111", Direccion="calle 1111", Email="a@o.com", RazonSocial="Prestador Internet 1", Telefono="1111" },
                    new PrestadorInternet { CUIT="22222", Direccion="calle 2222", Email="a2@2o.com", RazonSocial="Prestador Internet 2", Telefono="2222" },
                    new PrestadorInternet { CUIT="33333", Direccion="calle 3333", Email="a3@3o.com", RazonSocial="Prestador InternetPrestador Internet 3", Telefono="3333" }                    
                };

            var tipoServicioPrestadoInternet = new TipoServicioPrestado { Descripcion = "Servicio de Internet" };

            foreach (var item in prestadoresInternet)
            {
                item.TipoServicioPrestado = tipoServicioPrestadoInternet;
                context.PrestadoresInternet.Add(item);
            }
            #endregion

            base.Seed(context);
        }
    }
}
