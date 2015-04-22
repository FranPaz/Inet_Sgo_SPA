inetApp.service('dictInstSvc', function () {

    //#region Datos Basicos Dictamen
    var infoDictamen = {}; //variable global donde voy a guardar la escuela seleccionada al crear el dictamen institucional
    var addInfoDictamen = function (newObj) {
        infoDictamen = newObj;
    }
    //#endregion    

    var limpiarDictamen = function () {
        $scope.escuelaBuscada = null;
        $scope.campoBuscado = null;
        $scope.lineas = [];
        $scope.lineaSeleccionada = null;
        $scope.dictamen = null;
    };

    return {
        getInfoDictamen: function () {//devuelve la info basica del dictamen
            return infoDictamen;    
        },
        addInfoDictamen: addInfoDictamen,
        limpiarDictamen: limpiarDictamen
    };
});