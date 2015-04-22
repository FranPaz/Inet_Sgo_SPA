inetApp.controller('tlJurisdicCtrl', function ($scope, tlJurisdicDataFactory, $stateParams, $state, listadoLineasJurisdic, listadoCamposProg, infoCampoProg) {

    $scope.lineas = listadoLineasJurisdic; // var donde voy a guardar todos los tipos de lineas de campos prog ya sea cuando se cargue la pagino o cuando agregue uno nuevo

    $scope.infoLinea; // var que voy a usar para el abm

    $scope.editValue = false; // variable que voya usarpara activar y desactivar los modos de edicion 
    $scope.addValue = true; //para activar el alta de Lineas
    $scope.adminLineaCollapse = true; //var para hacer el collapse de la seccion Admin

    $scope.CamposProg = listadoCamposProg;
    $scope.campoProg = {};
    $scope.campoProg.selected = {};

    //#region Alta de Lineas para los Campos Programaticos

    //funcion para actualizar la tabla con la nueva linea
    $scope.addLinea = function () {
        $scope.lineas = tlJurisdicDataFactory.query({ prmIdCampoProg: $stateParams.campoProgId });
    };

    //funcion para guardar una nueva linea
    $scope.lineaAdd = function (linea) {
        linea.CampoProgramaticoId = infoCampoProg.Id;
        tlJurisdicDataFactory.save(linea).$promise.then(
            function () {
                $scope.addLinea();
                $scope.infoLinea = null;
                alert('Nueva Linea de Accion Guardada');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar la Linea de Accion');
            });
    };
    //#endregion

    // devuelve los datos detallados de la Linea de Accion para la seccion Administracion       
    $scope.detalle = function (linea) {
        $scope.addValue = false;
        $scope.infoLinea = tlJurisdicDataFactory.get({ prmIdCampoProg: $stateParams.campoProgId, prmIdLinea: linea.Id });
        $scope.adminLineaCollapse = false;
    };

    // limpia los campos de admin. y los deja listo para agregar un nuevo registro o limpiar los datos q actualmente estoy escribiendo
    $scope.clear = function () {
        $scope.infoLinea = null;
        if (!$scope.addValue) {
            $scope.editValue = false;
            $scope.addValue = true;
        }
    };

    //#region Modificacion de Lineas de Accion de Campos Programaticos
    $scope.edit = function () {// activa el modo de edicion de los campos        
        $scope.editValue = true;
    };

    $scope.save = function (linea) {// guarda los cambios y llama a la funcion put de la api          
        tlJurisdicDataFactory.update({ id: linea.Id }, linea).$promise.then(
                function () {
                    $scope.lineas = tlJurisdicDataFactory.query({ prmIdCampoProg: $stateParams.campoProgId });
                    $scope.editValue = false;
                    alert("Modificacion de Datos Exitosa");
                },
                function (response) {
                    //$scope.infoEncargado = $scope.infoEscuelaOriginal;
                    alert("Error en la Modificacion de Datos", response.data);
                });
    };

    $scope.cancel = function () {
        $scope.infoLinea = tlJurisdicDataFactory.get({ prmIdCampoProg: $stateParams.campoProgId, prmIdLinea: $scope.infoLinea.Id });
        $scope.editValue = false;
    };
    //#endregion

    //#region Eliminacion de Lineas de Accion de Campos Programaticos
    $scope.delete = function (linea) {
        tlJurisdicDataFactory.delete(linea).$promise.then(
            function () {
                $scope.lineas = tlJurisdicDataFactory.query({ prmIdCampoProg: $stateParams.campoProgId });
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