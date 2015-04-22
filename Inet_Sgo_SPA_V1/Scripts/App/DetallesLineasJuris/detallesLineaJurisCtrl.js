inetApp.controller('detallesLineaJurisCtrl', function ($scope, $modalInstance, $state, $previousState, tiposDetallesJurisDataFactory, prmTipoCampo, detalleLineaJurisSvc) {

    //#region Inicializacion de Variables de Scope        
    $scope.tiposDetalles = tiposDetallesJurisDataFactory.query({ id: $state.params.prmIdTipoCampoJuris });    
    $scope.tipoCampo = prmTipoCampo;
    $scope.tipoDetalleElegido = {};
    $scope.detalle = {};
    //#endregion

    $scope.cargarInfoDetalle = function () {
        detalleLineaJurisSvc.addInfoDetalleJuris($scope.detalle); //cargo en el svc la info basica del detalle jurisdiccional que voy a cargar
    }

    $scope.cargarFormTipoDetalle = function (item, model) {
        $scope.detalle.TipoDetalleJurisdiccionalId = model.Id;
        

        detalleLineaJurisSvc.addInfoDetalleJuris($scope.detalle); //cargo en el svc la info basica del detalle jurisdiccional que voy a cargar

        if (model.Descripcion == 'Servicio de Administrador de Red') {
            $state.go('detallesJuris.serviciosAdminRed');
        }

        if (model.Descripcion == 'Servicio de Internet') {
            $state.go('detallesJuris.serviciosInternet');
        }

        if (model.Descripcion == 'Servicio de Instalacion de Piso Tecnologico') {
            $state.go('detallesJuris.serviciosInstalacion');
        }
    }

    $scope.$on('limpiarDetalles', function () { // recivo el evento definido para limpiar los campos del detalles y dejarlo limpio para cargar uno nuevo
        $scope.detalle = {};
        $scope.tipoDetalleElegido = {};
    });

    var isopen = true;
    $modalInstance.result.finally(function () {
        isopen = false;
    });
    $scope.close = function () {
        $modalInstance.dismiss('close');
        $previousState.go("modalInvoker"); // return to previous state
    };
    $scope.$on("$stateChangeStart", function (evt, toState) {
        if (!toState.$$state().includes['detallesJuris']) {
            $modalInstance.dismiss('close');
        }
    });

});