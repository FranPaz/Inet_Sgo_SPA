inetApp.controller('comprobantesCtrl', function ($scope, comprobantesDataFactory, $stateParams, $state, listadoComprobantes) {

    //fpaz: trae todos los comprobantes
    $scope.comprobantes = listadoComprobantes;

    //#region funciones para ALTA de Comprobantes

    //funcion para agregar un nuevo Comprovante y mostrarlo en el listado
    $scope.addComprobante = function (comprobante) {
        $scope.comprobantes.push(comprobante);
    };

    $scope.altaComprobante = function (comprobante) {
        comprobantesDataFactory.save(comprobante).$promise.then(
            function () {
                //$scope.addComprobante(comprobante);
                alert('Nuevo Comprobante Guardado');
            },
            function (response) {
                $scope.errors = response.data;
                alert('Error al guardar comprobante');
            });
    };
    //#endregion

});