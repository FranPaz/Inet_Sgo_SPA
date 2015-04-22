inetApp.controller('servInternetCtrl', function ($scope, listadoEscuelas) {

    //#region Inicializacion de Variables de Scope
    $scope.escuelas = listadoEscuelas; //var donde guardo el listado de escuelas para poder seleccionar cual se va a a asociar al dictamen institucional al hacer el abm    
    $scope.escuelaBuscada = {};
    //#endregion     
});