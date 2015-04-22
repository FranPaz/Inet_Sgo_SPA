inetApp.controller('dictInstCtrl', function ($scope, dictInstDataFactory, $stateParams, $state, $filter, ngTableParams, dictInstSvc, listadoEscuelas, listadoCampos, dictamenSvc) {

    //#region Inicializacion de variables de Scope
    $scope.escuelas = listadoEscuelas; //var donde guardo el listado de escuelas para poder seleccionar cual se va a a asociar al dictamen institucional al hacer el abm
    $scope.camposProg = listadoCampos; //var donde guardo el listado de escuelas para poder seleccionar cual se va a a asociar al dictamen institucional al hacer el abm    
    $scope.escuelaBuscada = {};
    $scope.campoBuscado = {};
    $scope.lineas = [];// var que va guardando las lineas de el campo programatico seleccionando y se usan en la seleccion de lineas
    $scope.lineaSeleccionada = {};
    $scope.addDictamenCollapse = true;
    //#endregion

    $scope.addInfoDictamen = function () {
        dictInstSvc.addInfoDictamen ($scope.dictamen);
    }

    $scope.mostrarLineas = function (item, model) { // fpaz: carga el listado de lineas de accion correspondite al campo prog para su seleccion
        $scope.lineas = model.TiposLineasInstitucionales;
    };

    //#region Agregacion de Lineas de Accion al Dictamen
    $scope.lineasAgregadas=[]
    $scope.addLinea = function () {
        var nuevaLinea = {};
        nuevaLinea.MontoAprobado = $scope.lineaSeleccionada.MontoAprobado;
        nuevaLinea.MontoSolicitado = $scope.lineaSeleccionada.MontoSolicitado;
        nuevaLinea.TipoTipoLineaInstitucionalId = $scope.lineaSeleccionada.selected.Id;
        nuevaLinea.infoLinea = $scope.lineaSeleccionada.selected;
        $scope.lineasAgregadas.push(nuevaLinea);
        $scope.lineaSeleccionada = {};
    }
    //#endregion

    //#region Alta de Dictamen
    //funcion para agregar un nuevo Dictamen y mostrarlo en la tabla
    $scope.addTablaDictamen = function () {
        dictamenSvc.refreshListDictamenInst(); // llamo a la funcion del Svc para actualizar el grid de dictamenes institucionales
    };

    //funcion para dar de alta en la bd el nuevo dictamen
    $scope.dictamenAdd = function (dictamen) {
        var dictamenInst = {};
        dictamenInst = dictInstSvc.getInfoDictamen();
        dictamenInst.CampoProgramaticoId = $scope.campoBuscado.selected.Id;
        dictamenInst.EscuelaId = $scope.escuelaBuscada.selected.Id;
        dictamenInst.LineasInstitucionalesDictamen = $scope.lineasAgregadas;

        dictInstDataFactory.save(dictamenInst).$promise.then(
           function () {
               $scope.addTablaDictamen();
               $scope.LimpiarDictamen();
               alert('Nuevo Dictamen Guardado');
           },
           function (response) {
               $scope.errors = response.data;
               alert('Error al guardar el Dictamen ');
           });

    }
    //#endregion

    //#region Limpieza de campos
    // limpia los campos de admin. y los deja listo para agregar un nuevo registro o limpiar los datos q actualmente estoy escribiendo    
    $scope.cancel = function () {
        $scope.escuelaBuscada = null;
        $scope.campoBuscado = null;
        $scope.lineas = [];// var que va guardando las lineas de el campo programatico seleccionando y se usan en la seleccion de lineas
        $scope.lineaSeleccionada = null;
        $scope.dictamen = null;
        $scope.lineasAgregadas = []
    };

    $scope.LimpiarDictamen = function () {
        $scope.escuelaBuscada = null;
        $scope.campoBuscado = null;
        $scope.lineas = [];// var que va guardando las lineas de el campo programatico seleccionando y se usan en la seleccion de lineas
        $scope.lineaSeleccionada = null;
        $scope.dictamen = null;
        $scope.lineasAgregadas = []
    };
    //#endregion    

    //#region Chart Pie de Dictamenes Institucionales

    //$scope.dictamenesInst = [{ dictamen: '12682/2013', fecha: '30/10/2013', codPlan: 'STG_III_860165800_13', montoAprobado: '$373.942' },
    //{ dictamen: '10857/2012', fecha: '17/12/2012', codPlan: 'stgi086/212', montoAprobado: '$507.550' },
    //{ dictamen: '8082/2011', fecha: '12/10/2011', codPlan: 'STGI003/811', montoAprobado: '$22.470' }];

    //var chart1 = {};
    //chart1.type = "PieChart";
    //chart1.data = [
    //   ['Component', 'cost'],
    //   ['Software', 50000],
    //   ['Hardware', 80000]
    //];
    //chart1.data.push(['Services', 20000]);
    //chart1.options = {
    //    displayExactValues: true,
    //    width: 400,
    //    height: 200,
    //    is3D: true,
    //    chartArea: { left: 10, top: 10, bottom: 0, height: "100%" }
    //};

    //chart1.formatters = {
    //    number: [{
    //        columnNum: 1,
    //        pattern: "$ #,##0.00"
    //    }]
    //};

    //$scope.chart = chart1;

    //$scope.aa = 1 * $scope.chart.data[1][1];
    //$scope.bb = 1 * $scope.chart.data[2][1];
    //$scope.cc = 1 * $scope.chart.data[3][1];

    //#endregion    

    //#region Loader
    $scope.loading = true;

    $scope.$on('loader_show', function () {
        return $scope.loading = true;
    });

    $scope.$on('loader_hide', function () {
        return $scope.loading = false;
    });
    //#endregion
});