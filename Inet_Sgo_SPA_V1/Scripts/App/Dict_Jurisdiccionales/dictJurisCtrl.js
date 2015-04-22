inetApp.controller('dictJurisCtrl', function ($scope, dictJurisDataFactory, $stateParams, $modal, $state, ngTableParams, dictJurisSvc, listadoCampos,dictRedesPisoInetDataFactory) {

    //#region Inicializacion de Variables de Scope    
    $scope.camposProg = listadoCampos; //var donde guardo el listado de escuelas para poder seleccionar cual se va a a asociar al dictamen institucional al hacer el abm    
    $scope.campoBuscado = {};
    $scope.lineas = [];// var que va guardando las lineas de el campo programatico seleccionando y se usan en la seleccion de lineas
    $scope.lineaSeleccionada = {};    

    $scope.addDictamenCollapse = true;
    $scope.listDictamenCollapse = false;
    //#endregion 

    // fpaz: carga el listado de lineas de accion correspondite al campo prog para su seleccion
    $scope.mostrarLineas = function (item, model) { 
        $scope.lineas = model.TiposLineasJurisdiccionales;
    };

    //#region Agregacion de Lineas de Accion al Dictamen
    $scope.lineasAgregadas = [];
    $scope.addLinea = function () {
        var nuevaLinea = {};
        nuevaLinea.MontoAprobado = $scope.lineaSeleccionada.MontoAprobado;
        nuevaLinea.MontoSolicitado = $scope.lineaSeleccionada.MontoSolicitado;
        nuevaLinea.TipoLineaJurisdiccionalId = $scope.lineaSeleccionada.selected.Id;
        nuevaLinea.infoLinea = $scope.lineaSeleccionada.selected;
        nuevaLinea.detalles = []; // tiene todos los objetos detalles cargados para la linea
        nuevaLinea.cantDetalles = 0;//tiene el numero de detalles cargados para la linea
        $scope.lineasAgregadas.push(nuevaLinea);
        dictJurisSvc.addLineaJuris(nuevaLinea);
        $scope.lineaSeleccionada = {};        
    }

    // recivo el evento definido para actualizar las lineas del grid con la cantidad de detalles
    $scope.$on('refreshLineasJuris', function () { 
        $scope.lineasAgregadas = dictJurisSvc.getLineasJuris();
    });

    //#endregion

    //#region Alta de Dictamen
    $scope.addInfoDictamen = function () { //carga los datos basicos del dictamen
        dictJurisSvc.addInfoDictamen($scope.dictamen);
    }

    //funcion para mostrar un nuevo Dictamen cargado en la tabla de dictamenes
    $scope.addTablaDictamen = function () {
        $scope.dictamenes = dictInstDataFactory.query();
    };

    //funcion para dar de alta en la bd el nuevo dictamen
    $scope.dictamenAgregado = {};
    $scope.dictamenAdd = function () {

        var dictamenJuris = {};// declaro la variable que va a tener todos los datos del dictamen jurisdiccional
        dictamenJuris = dictJurisSvc.getInfoDictamen(); // cargo los datos basicos del dictamen
        dictamenJuris.CampoProgramaticoId = $scope.campoBuscado.selected.Id; // cargo el campo jurisdiccional asociado al dictamen
        dictamenJuris.LineasJurisdiccionalesDictamen = [];   
        
        var lineasCustom = [];        
                
        for (var l in $scope.lineasAgregadas) { // 1° for es para armar las lineas con su informacion basica
            var lineaTmp = {};
            lineaTmp.fondosAdminRed = [];

            var lineaJurisCustom = {};
            lineaJurisCustom.fondosAdminRed = [];
            lineaJurisCustom.fondosInstalacionRedPiso = [];
            lineaJurisCustom.fondosServicioInternet = [];

            lineaTmp.MontoAprobado = $scope.lineasAgregadas[l].MontoAprobado;            
            lineaTmp.MontoSolicitado = $scope.lineasAgregadas[l].MontoSolicitado;
            lineaTmp.TipoLineaJurisdiccionalId = $scope.lineasAgregadas[l].TipoLineaJurisdiccionalId;

            lineaJurisCustom.lineaJurisdiccionalDictamen = lineaTmp;

            //cargo los detalles de la linea            
            for (var d in $scope.lineasAgregadas[l].detalles) { // 2° for es para armar los detalles de la linea
                var fondoTmp = {};
                fondoTmp.ServiciosAdminRed = [];
                fondoTmp.DescripcionDetallada = $scope.lineasAgregadas[l].detalles[d].Descripcion;
                fondoTmp.MontoFinanciado = $scope.lineasAgregadas[l].detalles[d].MontoFinanciado;
                fondoTmp.MontoInventariableAprobado = $scope.lineasAgregadas[l].detalles[d].MontoInvAprobado;
                fondoTmp.MontoNoInventariableAprobado = $scope.lineasAgregadas[l].detalles[d].MontoNoInvAprobado;
                fondoTmp.EscuelaId = $scope.lineasAgregadas[l].detalles[d].EscuelaId;
                fondoTmp.TipoDetalleJurisdiccionalId = $scope.lineasAgregadas[l].detalles[d].TipoDetalleJurisdiccionalId;
                
                for (var s in $scope.lineasAgregadas[l].detalles[d].Servicios) {// 3° for es para cargar los servicios que forman del detalle (subdetalles)
                    var servicioTmp = {};
                    servicioTmp.MontoMensual = $scope.lineasAgregadas[l].detalles[d].Servicios[s].MontoMensual;
                    servicioTmp.HorasMes = $scope.lineasAgregadas[l].detalles[d].Servicios[s].HorasMes;
                    servicioTmp.FechaInicio = $scope.lineasAgregadas[l].detalles[d].Servicios[s].FechaInicio;
                    servicioTmp.FechaFin = $scope.lineasAgregadas[l].detalles[d].Servicios[s].FechaFin;
                    servicioTmp.Turno = $scope.lineasAgregadas[l].detalles[d].Servicios[s].Turno;
                    servicioTmp.AdministradorDeRedId = $scope.lineasAgregadas[l].detalles[d].Servicios[s].AdministradorDeRed.Id;
                    fondoTmp.ServiciosAdminRed.push(servicioTmp);
                }

                lineaTmp.fondosAdminRed.push(fondoTmp);
                lineaJurisCustom.fondosAdminRed.push(fondoTmp);
            }            

            lineasCustom.push(lineaJurisCustom);
            //dictamenJuris.LineasJurisdiccionalesDictamen.push(lineaTmp);            
        }

        $scope.dictamenAgregado = dictamenJuris;

        var dictAdminPisoInetCustom = {};
        dictAdminPisoInetCustom.dictamenJurisdiccional = dictamenJuris;
        dictAdminPisoInetCustom.lineasJurisCustom = lineasCustom;
        
        dictRedesPisoInetDataFactory.save(dictAdminPisoInetCustom).$promise.then(
           function () {
               //$scope.addTablaDictamen();
               $scope.limpiarDictamen();
               alert('Nuevo Dictamen Guardado');
           },
           function (response) {
               $scope.errors = response.data;
               alert('Error al guardar el Dictamen ');
           });

    }
    //#endregion

    //#region Limpieza Dictamen    
    $scope.limpiarDictamen = function () {// limpia los campos para cargar un nuevo dictamen jurisdiccional y los deja listo para la proxima carga
        $scope.escuelaBuscada = {};
        $scope.campoBuscado = {};
        $scope.lineas = [];// var que va guardando las lineas de el campo programatico seleccionando y se usan en la seleccion de lineas
        $scope.lineaSeleccionada = {};
        $scope.dictamen = {};
        $scope.lineasAgregadas = [];
        $scope.dictamenAgregado = {};
    }

    $scope.cancel = function () {
        $scope.limpiarDictamen();
    };
    //#endregion
});