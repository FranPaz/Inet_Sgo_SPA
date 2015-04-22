inetApp.controller('camposProgCtrl', function ($scope, camposProgDataFactory, $stateParams, $state, listadoTiposCamposProg, listadoCamposProg, infoCampoProg, listadoTiposCamposJuris) {
    
    //#region Inicializacion de variables de Scope
    $scope.camposProg = listadoCamposProg; // var donde voy a guardar todos los campos prog ya sea cuando se cargue la pagino o cuando agregue uno nuevo
    $scope.infoCampoProg = infoCampoProg; // var que voy a usar para el abm
    $scope.editValue = false; // variable que voya usarpara activar y desactivar los modos de edicion 
    $scope.addValue = true; //para activar el alta de Campos
    $scope.adminCamposCollapse = true; //var para hacer el collapse de la seccion Admin de Campos Prog

    $scope.tiposCamposProg = listadoTiposCamposProg;
    $scope.tipo = {};
    $scope.tipo.selected = {};

    $scope.tiposCamposJuris = listadoTiposCamposJuris;
    $scope.tipoJuris = {};
    $scope.tipoJuris.selected = {};
    $scope.showTipoCampoJuris = false;

    //#endregion

    //#region Alta de Campos Programaticos
    //funcion para agregar un nuevo Campos Programaticos y mostrarlo en la tabla
    $scope.addCampoProg = function () {
        $scope.camposProg = camposProgDataFactory.query();
    };

    $scope.campoProgAdd = function (campoProg) {
        campoProg.TipoCampoProgramaticoId = $scope.tipo.selected.Id;

        if ($scope.tipo.selected.Id != null) {
            campoProg.TipoCampoJurisdiccionalId = $scope.tipoJuris.selected.Id;
        }        
        camposProgDataFactory.save(campoProg).$promise.then(
            function () {
                $scope.addCampoProg();
                $scope.infoCampoProg = null;
                alert('Nuevo Campo Programatico Guardado');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar el Campo Programatico');
            });
    };
    //#endregion

    // devuelve los datos detallados del campo programatico para la seccion Administracion       
    $scope.detalle = function (campoProg) { 
        $scope.addValue = false;        
        $scope.infoCampoProg = camposProgDataFactory.get({ id: campoProg.Id });        
        if (campoProg.TipoCampoProgramatico.Descripcion == 'Campo Jurisdiccional') {
            $scope.showTipoCampoJuris = true;
        } else {
            $scope.showTipoCampoJuris = false;
        }
        $scope.adminCamposCollapse = false;        
    };

    // limpia los campos de admin. y los deja listo para agregar un nuevo registro o limpiar los datos q actualmente estoy escribiendo
    $scope.clear = function () { 
        $scope.infoCampoProg = null;

        $scope.tipo = {};
        $scope.tipo.selected = {};

        $scope.tipoJuris = {};
        $scope.tipoJuris.selected = {};
        $scope.showTipoCampoJuris = false;

        if (!$scope.addValue) {
            $scope.editValue = false;
            $scope.addValue = true;
        }
    };

    //#region Modificacion de Campos Programaticos
    $scope.edit = function () {// activa el modo de edicion de los campos        
        $scope.editValue = true;
        $scope.tipo.selected = $scope.infoCampoProg.TipoCampoProgramatico;

        if ($scope.infoCampoProg.TipoCampoProgramatico.Descripcion == 'Campo Jurisdiccional') {
            $scope.tipoJuris.selected = $scope.infoCampoProg.TipoCampoJurisdiccional;
        }
    };

    $scope.save = function (campoProg) {// guarda los cambios y llama a la funcion put de la api  
        campoProg.TipoCampoProgramatico = $scope.tipo.selected;
        campoProg.TipoCampoProgramaticoId = $scope.tipo.selected.Id;

        campoProg.TipoCampoJurisdiccional = $scope.tipoJuris.selected;
        campoProg.TipoCampoJurisdiccionalId = $scope.tipoJuris.selected.Id;

        camposProgDataFactory.update({ id: campoProg.Id }, campoProg).$promise.then(
                function () {
                    $scope.camposProg = camposProgDataFactory.query();
                    $scope.editValue = false;
                    alert("Modificacion de Datos Exitosa");
                },
                function (response) {
                    //$scope.infoEncargado = $scope.infoEscuelaOriginal;
                    alert("Error en la Modificacion de Datos", response.data);
                });
    };

    $scope.cancel = function () {
        $scope.infoCampoProg = camposProgDataFactory.get({ id: $scope.infoCampoProg.Id });
        $scope.editValue = false;
        $scope.tipo = {};
        $scope.tipo.selected = {};

        $scope.tipoJuris = {};
        $scope.tipoJuris.selected = {};
        
    };
    //#endregion

    //#region Eliminacion de Campos Programaticos
    $scope.delete = function (campoProg) {
        camposProgDataFactory.delete(campoProg).$promise.then(
            function () {
                $scope.camposProg = camposProgDataFactory.query();
                $scope.clear();
                alert("Eliminacion Exitosa");
            },
            function (response) {
                alert("Eliminacion Fallida", response.data);
                //$scope.resultado = 'Error Eliminacion';
            });
    };
    //#endregion

    //funcion para mostrar ir a la vista de lineas de campos institucionales o jurisdiccionales segun corresponda
    $scope.isInstitucional = function (tipo) {
        if (tipo == 'Campo Institucional') {            
            return true
        } else {            
                return false
        }
    };

    $scope.mostrarTiposCamposJuris = function (item, model) {
        //alert(model.Descripcion);
        if (model.Descripcion == 'Campo Jurisdiccional') {
            //alert(tipo);
            $scope.showTipoCampoJuris = true;
        } else {
            //alert(tipo);
            $scope.showTipoCampoJuris = false;
            $scope.tipoJuris = {};
            $scope.tipoJuris.selected = {};
        }
    };

});