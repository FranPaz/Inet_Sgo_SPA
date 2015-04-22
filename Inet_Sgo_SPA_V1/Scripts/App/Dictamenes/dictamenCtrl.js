inetApp.controller('dictamenCtrl', function ($scope, $stateParams, $state, $filter, ngTableParams,listadoDictamenes, tituloListado,dictamenSvc) {
    //#region Inicializacion de variables de Scope
    $scope.dictamenes = listadoDictamenes; // var donde voy a guardar el listado de dictamenes institucionales guardados    
    $scope.titulo = tituloListado;
    $scope.listDictamenCollapse = false;
    //#endregion

    $scope.$on('refreshDictInst', function () { // recivo el evento definido para permitir la solicitud de actualizacion del grid de dictamenes institucionales
        $scope.dictamenes = dictamenSvc.getListDictamenesInst();
        data = $scope.dictamenes;
    });

    $scope.$on('refreshDictJuris', function () {// recivo el evento definido para permitir la solicitud de actualizacion del grid de dictamenes jurisdiccionales
        $scope.dictamenes = dictamenSvc.getListDictamenesJuris();
        data = $scope.dictamenes;
    });

    //#region Paginacion de la tabla dinamica de Dictamenes (se puede llenar con dictamenes Institucionales o Jurisdiccionales segun la opcion elegida)
    var data = $scope.dictamenes;
    $scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10,          // count per page        
        filter: {
            // filtros de la tabla, 
            NroDictamen: '', //por numero de NroDictamen       
            CodPlanMejora: ''// por nombre de CodPlanMejora
        },
        sorting: {
            name: 'asc'
        }
    }, {
        total: data.length, // saco el Total de registros del listado de escuelas
        getData: function ($defer, params) {
            var filteredData = params.filter() ?
                   $filter('filter')(data, params.filter()) :
                   data;

            var orderedData = params.sorting() ?
                   $filter('orderBy')(filteredData, params.orderBy()) :
                   data;

            $scope.dictamenes = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());
            params.total(orderedData.length); // set total for recalc pagination
            $defer.resolve($scope.dictamenes);
        }
    });
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