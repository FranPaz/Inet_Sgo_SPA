var inetApp = angular.module('inetApp', ['ngRoute', 'ngResource', 'ui.router', 'ngCookies', 'ui.bootstrap', 'ngTable', 'googlechart',
  'ngSanitize', 'ngAnimate', 'ui.select', 'ct.ui.router.extras'])
    .config(function ($stateProvider, $urlRouterProvider, $httpProvider,$stickyStateProvider) {

        $httpProvider.interceptors.push('httpInterceptor');

        $urlRouterProvider.otherwise("/");

        $stateProvider //fpaz: defino los states que van a guiar el ruteo de las vistas parciales de la app       
        //#region Home
          .state('home', {
              url: "/",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Dashboard/Partials/Content.html',
                      controller: ''
                  }
              }
          })
        //#endregion  

        //#region Escuelas
          .state('escuelas', {
              url: "/Escuelas",
              views: {
                  'content': {
                      templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Main.html',
                      controller: 'escuelasCtrl',
                      resolve: {
                          escuelasDataFactory: 'escuelasDataFactory',
                          infoEscuela: function () {
                              return { value: [] };
                          },
                          listadoEscuelas: function (escuelasDataFactory) {
                              return escuelasDataFactory.query();
                          },
                          estadoActual: function () {
                              return { value: [] };
                          }
                      }
                  }
              }
          })
            .state('escuelasDetailBase', {
                abstract: true,
                views: {
                    'content': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail.html',
                        controller: '',
                        resolve: {
                            listadoEscuelas: function () {
                                return { value: [] };
                            }
                        }
                    }
                }
            })
            .state('escuelasDetailBase.detail', {
                url: "/Escuela/Detail/:escuelaId",
                views: {
                    'info': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_Info.html',
                        controller: 'escuelasCtrl',
                        resolve: {
                            escuelasDataFactory: 'escuelasDataFactory',
                            infoEscuela: function (escuelasDataFactory, $stateParams) {
                                //fpaz: trae los datos de una escuela en particular
                                var escuelaId = $stateParams.escuelaId;
                                return escuelasDataFactory.get({ id: escuelaId }).$promise;
                            },
                            listadoEscuelas: function () {
                                return { value: [] };
                            },
                            estadoActual: function ($state) {
                                return $state;
                            }
                        }
                    },
                    'encargados': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_Encargados.html',
                        controller: 'encargadosCtrl',
                        resolve: {
                            encargadosDataFactory: 'encargadosDataFactory',
                            listadoEncargados: function (encargadosDataFactory, $stateParams) {
                                var escuelaId = $stateParams.escuelaId;
                                return encargadosDataFactory.query({ prmIdEscuela: escuelaId });
                            },
                            estadoActual: function ($state) {
                                return $state;
                            },
                            escuelaId: function ($stateParams) {
                                //fpaz: trae el Id de una escuela en particular
                                return $stateParams.escuelaId;
                            },
                            tipoCargosEncargadosDataFactory: 'tipoCargosEncargadosDataFactory',
                            tiposCargos: function (tipoCargosEncargadosDataFactory) {
                                return tipoCargosEncargadosDataFactory.query();
                            }
                        }
                    },
                    'infoDictInst': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_DictInst.html',
                        controller: '',
                        resolve: {
                        }
                    },
                    'infoDictJuridisc': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_DictJuridic.html',
                        controller: '',
                        resolve: {
                        }
                    },
                    'adminRed': {
                        templateUrl: '/Scripts/App/Escuelas/Partials/Escuelas_Detail_AdmRedes.html',
                        controller: '',
                        resolve: {
                        }
                    }
                }
            })
        //#endregion  

        //#region Comprobantes
        .state('tiposComprobantes', {
            url: "/Comprobantes",
            views: {
                'content': {
                    templateUrl: '/Scripts/App/Comprobantes/Comprobante_Add.html',
                    resolve: {
                        comprobantesDataFactory: 'comprobantesDataFactory',
                        listadoComprobantes: function () {
                            return { value: [] };
                        },
                        //listadoClientes: function (clientesDataFactory) {
                        //    return clientesDataFactory.query();
                        //},                        
                    },
                    controller: 'comprobantesCtrl'
                }
            }
        })
        //#endregion

        //#region Campos Programaticos
        .state('camposProg', {
            url: "/CamposProgamaticos",
            views: {
                'content': {
                    templateUrl: '/Scripts/App/CamposProgramaticos/Partials/CamposProg_Main.html',
                    controller: 'camposProgCtrl',
                    resolve: {                        
                        tiposCamposProgDataFactory: 'tiposCamposProgDataFactory',
                        listadoTiposCamposProg: function (tiposCamposProgDataFactory) {
                            return tiposCamposProgDataFactory.query();
                        },
                        camposProgDataFactory: 'camposProgDataFactory',
                        listadoCamposProg: function (camposProgDataFactory) {
                            return camposProgDataFactory.query();
                        },
                        infoCampoProg: function () {                            
                            return { value: [] };
                        },
                        tiposCamposJurisDataFactory: 'tiposCamposJurisDataFactory',
                        listadoTiposCamposJuris: function (tiposCamposJurisDataFactory) {
                            return tiposCamposJurisDataFactory.query();
                        }
                    }
                }
            }
        })
            .state('camposProgLineasBase', {
                abstract: true,
                views: {
                    'content': {
                        templateUrl: '/Scripts/App/CamposProgramaticos/Partials/CamposProg_Lineas.html',
                        controller: '',
                        resolve: {
                            listadoEscuelas: function () {
                                return { value: [] };
                            }
                        }
                    }
                }
            })
                .state('camposProgLineasBase.lineasIntitucionales', {
                    url: "/CamposProgamaticos/:campoProgId/LineasIntitucionales",
                    views: {
                        'infoCampoProg': {
                            templateUrl: '/Scripts/App/CamposProgramaticos/Partials/CamposProg_Info.html',
                            controller: 'camposProgCtrl',
                            resolve: {                            
                                listadoTiposCamposProg: function () {
                                    return {value:[]};
                                },                            
                                listadoCamposProg: function () {
                                    return {value:[]};
                                },
                                camposProgDataFactory: 'camposProgDataFactory',
                                infoCampoProg: function (camposProgDataFactory, $stateParams) {
                                    //fpaz: trae los datos de una escuela en particular
                                    var campoProgId = $stateParams.campoProgId;
                                    return camposProgDataFactory.get({ id: campoProgId }).$promise;
                                },
                                listadoTiposCamposJuris: function () {
                                    return { value: [] };
                                }
                            }
                        },
                        'lineasCampoProg': {
                            templateUrl: '/Scripts/App/TiposLineasDeAccion/Partials/Lineas_Main.html',
                            controller: 'tlInstCtrl',
                            resolve: {
                                tlInstDataFactory: 'tlInstDataFactory',
                                listadoLineasInst: function (tlInstDataFactory, $stateParams) {
                                    //fpaz: trae los datos de una escuela en particular
                                    var campoProgId = $stateParams.campoProgId;
                                    return tlInstDataFactory.query({ prmIdCampoProg: campoProgId }).$promise;
                                },                            
                                listadoCamposProg: function () {
                                    return { value: [] };
                                },
                                camposProgDataFactory: 'camposProgDataFactory',
                                infoCampoProg: function (camposProgDataFactory, $stateParams) {                                
                                    var campoProgId = $stateParams.campoProgId;
                                    return camposProgDataFactory.get({ id: campoProgId }).$promise;
                                }
                            
                            }
                        }                    
                    }

                })
                .state('camposProgLineasBase.lineasJurisdiccionales', {
                    url: "/CamposProgamaticos/:campoProgId/LineasJurisdiccionales",
                    views: {
                        'infoCampoProg': {
                            templateUrl: '/Scripts/App/CamposProgramaticos/Partials/CamposProg_Info.html',
                            controller: 'camposProgCtrl',
                            resolve: {
                                listadoTiposCamposProg: function () {
                                    return { value: [] };
                                },
                                listadoCamposProg: function () {
                                    return { value: [] };
                                },
                                camposProgDataFactory: 'camposProgDataFactory',
                                infoCampoProg: function (camposProgDataFactory, $stateParams) {
                                    //fpaz: trae los datos de una escuela en particular
                                    var campoProgId = $stateParams.campoProgId;
                                    return camposProgDataFactory.get({ id: campoProgId }).$promise;
                                },
                                listadoTiposCamposJuris: function () {
                                    return { value: [] };
                                }
                            }
                        },
                        'lineasCampoProg': {
                            templateUrl: '/Scripts/App/TiposLineasDeAccion/Partials/Lineas_Main.html',
                            controller: 'tlJurisdicCtrl',
                            resolve: {
                                tlJurisdicDataFactory: 'tlJurisdicDataFactory',
                                listadoLineasJurisdic: function (tlJurisdicDataFactory, $stateParams) {                                    
                                    var campoProgId = $stateParams.campoProgId;
                                    return tlJurisdicDataFactory.query({ prmIdCampoProg: campoProgId }).$promise;
                                },
                                listadoCamposProg: function () {
                                    return { value: [] };
                                },
                                camposProgDataFactory: 'camposProgDataFactory',
                                infoCampoProg: function (camposProgDataFactory, $stateParams) {
                                    var campoProgId = $stateParams.campoProgId;
                                    return camposProgDataFactory.get({ id: campoProgId }).$promise;
                                }

                            }
                        }
                    }

                })
        //#endregion

        //#region Tipos Campos Programaticos
        .state('tiposCamposProg', {
            url: "/TiposCamposProg",
            views: {
                'content': {
                    templateUrl: '/Scripts/App/TiposCamposProg/TiposCamposProg_Add.html',
                    controller: 'tiposCamposProgCtrl'
                }
            }
        })
        //#endregion

        //#region Dictamenes
        .state('dictamenesBase', {
            abstract: true,
            views: {
                'content': {
                    templateUrl: '/Scripts/App/Dictamenes/Partials/Dictamenes_Main.html',
                    controller: ''
                }
            },
            sticky: true
        })
            .state('dictamenesBase.Institucional', {
                url: "/DictamenesInstitucionales",
                views: {                    
                    'infoTipoDictamen': {                            
                        templateUrl: '/Scripts/App/Dict_Institucionales/Partials/Dict_Inst_InfoAdd.html',
                        controller: 'dictInstCtrl',
                        resolve: {
                            escuelasDataFactory: 'escuelasDataFactory',                          
                            listadoEscuelas: function (escuelasDataFactory) {
                                return escuelasDataFactory.query();
                            },
                            camposProgDataFactory: 'camposProgDataFactory',
                            listadoCampos: function (camposProgDataFactory) {
                                return camposProgDataFactory.query({ id: 0, prmTipoCampo: 'Campo Institucional' });
                            }
                        }
                    },
                    'listaTipoDictamen': {
                        templateUrl: '/Scripts/App/Dictamenes/Partials/Dictamenes_List.html',
                        controller: 'dictamenCtrl',
                        resolve: {                                                        
                            dictInstDataFactory : 'dictInstDataFactory',
                            listadoDictamenes: function (dictInstDataFactory) {
                                return dictInstDataFactory.query();
                            },                            
                            tituloListado: function () {
                                return 'Listado de Dictamenes Institucionales' ;
                            }                            
                        }
                    }
                }
            })
            .state('dictamenesBase.Jurisdiccional', {
                url: "/DictamenesJurisdiccionales",                
                views: {                    
                    'infoTipoDictamen': {
                        templateUrl: '/Scripts/App/Dict_Jurisdiccionales/Partials/Dict_Jurisdic_InfoAdd.html',
                        controller: 'dictJurisCtrl',
                        resolve: {                            
                            camposProgDataFactory: 'camposProgDataFactory',
                            listadoCampos: function (camposProgDataFactory) {
                                return camposProgDataFactory.query({ id: 0, prmTipoCampo: 'Campo Jurisdiccional' });
                            }
                        }
                    },
                    'listaTipoDictamen': {
                        templateUrl: '/Scripts/App/Dictamenes/Partials/Dictamenes_List.html',
                        controller: 'dictamenCtrl',
                        resolve: {
                            dictJurisDataFactory: 'dictJurisDataFactory',
                            listadoDictamenes: function (dictJurisDataFactory) {
                                return dictJurisDataFactory.query();
                            },
                            tituloListado: function () {
                                return 'Listado de Dictamenes Jurisdiccionales';
                            }
                        }
                    }
                }
            })                
        //#endregion

        //#region Detalles Dictamenes Jurisdiccionales        
        .state('detallesJuris', { // Este es el Estado para mostrar el modal para la carga de detalles de dictamenes jurisdiccionales            
            url: "/DetallesJurisdic?prmIdTipoCampoJuris&prmTipoCampo&prmIndexLinea",
            template: '<div ui-view></div>',            
            onEnter: function showModal($modal, $previousState, $stateParams, dictJurisSvc) {
                $previousState.memo("modalInvoker"); // remember the previous state with memoName "modalInvoker"

                var modalInstance = $modal.open({
                    templateUrl: '/Scripts/App/DetallesLineasJuris/Partials/DetallesLineasJuris_Add_InfoGral.html',
                    size: 'lg',
                    backdrop: 'static',
                    controller: 'detallesLineaJurisCtrl',
                    resolve: {
                        prmTipoCampo: function () {
                            return $stateParams.prmTipoCampo;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    alert('entro por el ok');
                }, function () {
                    dictJurisSvc.refreshListLineasJuris(); //cuando salgo del modal de carga de detalles de linea juris actualizo el grid
                    //alert('entro por el cancel');
                });
            }
        })
        //#endregion

        //#region Administradores de Redes y Piso Tec - Servicios de Internet        
        .state('detallesJuris.serviciosInternet', {
            url: "/SeviciosInternet/AddDetalles",
            controller: '',
            templateUrl: '/Scripts/App/DictJuris_RedesPiso/Serv_Internet/Partials/DetallesLineasJuris_Add_ServiciosInternet.html',
            resolve: {
                escuelasDataFactory: 'escuelasDataFactory',
                listadoEscuelas: function (escuelasDataFactory) {
                    return escuelasDataFactory.query();
                }
            }
        })        
        //#endregion

        //#region Administradores de Redes y Piso Tec - Servicios de Administradores de Red        
        .state('detallesJuris.serviciosAdminRed', {
            url: "/SeviciosAdministradores/AddDetalles",
            controller: 'servAdminRedCtrl',
            templateUrl: '/Scripts/App/DictJuris_RedesPiso/Serv_Admin/Partials/DetallesLineasJuris_Add_ServiciosAdminRed.html',
            resolve: {
                escuelasDataFactory: 'escuelasDataFactory',
                listadoEscuelas: function (escuelasDataFactory) {
                    return escuelasDataFactory.query();
                },
                adminRedDataFactory: 'adminRedDataFactory',
                listadoAdminsRed: function (adminRedDataFactory) {
                    return adminRedDataFactory.query();
                }
            }
            
        })
        //#endregion

        //#region Administradores de Redes y Piso Tec - Servicios de Instalacion de Red y Piso        
        .state('detallesJuris.serviciosInstalacion', {
            url: "/SeviciosInstalacion/AddDetalles",
            controller: 'servInstalacionCtrl',
            templateUrl: '/Scripts/App/DictJuris_RedesPiso/Serv_Instalacion/Partials/DetallesLineasJuris_Add_ServiciosInstalacionRedPiso.html',
            resolve: {
                escuelasDataFactory: 'escuelasDataFactory',
                listadoEscuelas: function (escuelasDataFactory) {
                    return escuelasDataFactory.query();
                },
                instaladoresRedDataFactory: 'instaladoresRedDataFactory',
                listadoInstaladoresRed: function (instaladoresRedDataFactory) {
                    return instaladoresRedDataFactory.query();
                }
            }
        })
        //#endregion
    })

