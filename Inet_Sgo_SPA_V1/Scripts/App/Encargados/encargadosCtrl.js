inetApp.controller('encargadosCtrl', function ($scope, $stateParams, $state, $filter, ngTableParams, encargadosDataFactory, listadoEncargados, escuelaId, estadoActual, $location, tipoCargosEncargadosDataFactory, tiposCargos) {

    //#region Inicializacion  de variables de Scope
    $scope.state = $location.path(); //guardo la url actual para poder contraer los divs sin que angular quiera navegar con el href 
    $scope.infoEncargado;
    $scope.encargados = listadoEncargados;
    $scope.editValue = false; // variable que voya usarpara activar y desactivar los modos de edicion para hacer el update de la info de la escuela
    $scope.addValue = true; //para activar el alta de Encargados
    $scope.encargadosCollapse = true; //var para hacer el collapse de la seccion encargados de escuelas detail

    $scope.tiposCargos = tiposCargos;
    $scope.tipoCargo = {};
    $scope.tipoCargo.selected = {};
    //#endregion

    //#region Alta de Encargados
    //funcion para agregar un nuevo Encargado y mostrarla en la tabla
    $scope.addEncargados = function () {
        $scope.encargados = encargadosDataFactory.query({ prmIdEscuela: escuelaId });
    };

    $scope.encargadoAdd = function (encargado) {
        encargado.EscuelaId = escuelaId;
        encargado.TipoCargoEncargadoId = $scope.tipoCargo.selected.Id;

        encargadosDataFactory.save(encargado).$promise.then(
            function () {
                $scope.addEncargados();
                $scope.infoEncargado = null;                
                alert('Nuevo Encargado Guardado');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar el Encargado');
            });
    };
    //#endregion

    $scope.detalle = function (encargado) { // devuelve los datos detallados del encargado para la seccion Administracion de Encargados       
        $scope.addValue = false;
        var escId = escuelaId;
        $scope.infoEncargado = encargadosDataFactory.get({ prmIdEscuela: escId, prmIdEncargado: encargado.Id });
    };

    $scope.clear = function () { // limpia los campos de admin. de encargados y los deja listo para agregar un nuevo encargado o limpiar los datos q actualmente estoy escribiendo
        $scope.infoEncargado = null;
        if (!$scope.addValue) {
            $scope.editValue = false;
            $scope.addValue = true;
        }
    };

    //#region Modificacion de Encargados 

    $scope.edit = function () {// activa el modo de edicion de los campos        
        $scope.editValue = true;
    };

    $scope.save = function (infoEncargado) {// guarda los cambios y llama a la funcion put de la api        
        encargadosDataFactory.update({ id: infoEncargado.Id }, infoEncargado).$promise.then(
                function () {
                    $scope.encargados = encargadosDataFactory.query({ prmIdEscuela: escuelaId });
                    $scope.editValue = false;
                    alert("Modificacion de Datos Exitosa");
                },
                function (response) {
                    $scope.infoEncargado = $scope.infoEscuelaOriginal;
                    alert("Error en la Modificacion de Datos", response.data);
                });
    };

    $scope.cancel = function () {
        $scope.infoEncargado = encargadosDataFactory.get({ prmIdEscuela: escuelaId, prmIdEncargado: $scope.infoEncargado.Id });
        $scope.editValue = false;
    };
    //#endregion

    //#region Eliminacion de Encargados
    $scope.delete = function (infoEncargado) {
        encargadosDataFactory.delete(infoEncargado).$promise.then(
            function () {
                $scope.encargados = encargadosDataFactory.query({ prmIdEscuela: escuelaId });
                $scope.clear();
                alert("Eliminacion Exitosa");                
            },
            function (response) {
                alert("Eliminacion Fallida", response.data);
                //$scope.resultado = 'Error Eliminacion';
            });
    };
    //#endregion

    
});