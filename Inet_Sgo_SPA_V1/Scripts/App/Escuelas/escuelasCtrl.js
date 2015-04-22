inetApp.controller('escuelasCtrl', function ($scope, $stateParams, $state, $filter, ngTableParams, escuelasDataFactory, listadoEscuelas, infoEscuela, estadoActual,$location) {
    $scope.state = $location.path(); //guardo la url actual para poder contraer los divs sin que angular quiera navegar con el href 
    $scope.infoEscuela = infoEscuela;
    var infoActualEscuela = infoEscuela; 
    $scope.escuelas = listadoEscuelas;    
    var data = $scope.escuelas;

    $scope.infoCollapse = false; //var para hacer el collapse de la seccion info detallada de escuelas detail
    $scope.addEscuelaCollapse = true; //var para hacer el collapse de la seccion carga nueva escuela de escuelas_main
    $scope.listEscuelasCollapse = false; //var para hacer el collapse de la seccion Listados de escuelas de escuelas_main

    //#region Alta de Escuelas
    //funcion para agregar una nueva Escuela y mostrarla en la tabla
    $scope.addEscuela = function () {
        $scope.escuelas = escuelasDataFactory.query();
        data = $scope.escuelas;
    };

    $scope.escuelaAdd = function (escuela) {
        escuelasDataFactory.save(escuela).$promise.then(
            function () {
                $scope.addEscuela();
                $scope.escuela = {};
                alert('Nueva Escuela Guardada');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar la Escuela');
            });
    };

    $scope.cancelEscuelaAdd = function () {
        $scope.escuela = null;
    };
    //#endregion

    //#region Modificacion de Escuelas

    $scope.editValue = false; // variable que voya usarpara activar y desactivar los modos de edicion para hacer el update de la info de la escuela
    
    $scope.edit = function () {// activa el modo de edicion de los campos        
        $scope.editValue = true;        
    };

    $scope.save = function (infoEscuela) {// guarda los cambios y llama a la funcion put de la api        
        escuelasDataFactory.update({ id: infoEscuela.Id }, infoEscuela).$promise.then(
                function () {
                    $scope.editValue = false;
                    alert("Modificacion de Datos Exitosa");
                },
                function (response) {
                    $scope.infoEscuela = $scope.infoEscuelaOriginal;
                    alert("Error en la Modificacion de Datos", response.data);
                });
    };

    $scope.cancel = function () {
        $scope.infoEscuela = escuelasDataFactory.get({ id: infoEscuela.Id })
        $scope.editValue = false;        
    };

    //#endregion

    //#region Eliminacion de Escuelas
    $scope.delete = function (infoEscuela) {
        escuelasDataFactory.delete(infoEscuela).$promise.then(
            function () {
                alert("Eliminacion Exitosa");
                $state.go('escuelas');
            },
            function (response) {
                alert("Eliminacion Fallida", response.data);
                //$scope.resultado = 'Error Eliminacion';
            });
    };
    //#endregion

    //#region Paginacion y llenado y filtrado de la tabla dinamica de Escuelas
    $scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10,          // count per page
        filter: {
            // filtros de la tabla, 
            CUE: '', //por numero de CUE       
            Nombre:''// por nombre de Escuela
        }
    }, {
        total: data.length, // saco el Total de registros del listado de escuelas
        getData: function ($defer, params) {
            // use build-in angular filter
            var orderedData = params.filter() ?
                   $filter('filter')(data, params.filter()) :
                   data;

            //$defer.resolve(data.slice((params.page() - 1) * params.count(), params.page() * params.count()));
            $scope.escuelas = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());

            params.total(orderedData.length); // set total for recalc pagination
            $defer.resolve($scope.escuelas);       
        }
    });
    //#endregion

    //#region Loader
    $scope.loading = true;

    $scope.$on('loader_show', function () {        
        return $scope.loading= true;
    });

    $scope.$on('loader_hide', function () {        
        return $scope.loading = false;
    });
    //#endregion
});