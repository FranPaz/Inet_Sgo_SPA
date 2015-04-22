inetApp.service('detalleLineaJurisSvc', function ($rootScope) {

    //#region Datos del Detalle Jurisdiccional
    var infoDetalleJuris = {}; //variable global donde voy a guardar el detalle de la linea jurisdiccional
    var addInfoDetalleJuris = function (newObj) {
        infoDetalleJuris = newObj;
    }

    var subDetallesJuris = {};
    var addSubDetallesJuris = function (newObj) {
        subDetallesJuris = newObj;
    }
    //#endregion

    //#region limpieza de datalles jurisdiccionales
    var limpiarDetalleJuris = function () { //funcion que manda el broadcast para limpiar los campos que estan en diferentes scopes y se usan para cargar un detalle
        $rootScope.$broadcast('limpiarDetalles');
    };
    //#endregion

    return {
        getInfoDetalleJuris: function () {//devuelve la info basica del detalle jursdiccional que voy a cargar
            return infoDetalleJuris;
        },
        addInfoDetalleJuris: addInfoDetalleJuris,
        limpiarDetalleJuris: limpiarDetalleJuris,
        getSubDetallesJuris: function () {//devuelve la info basica del detalle jursdiccional que voy a cargar
            return subDetallesJuris;
        },
        addSubDetallesJuris: addSubDetallesJuris,
    };
});