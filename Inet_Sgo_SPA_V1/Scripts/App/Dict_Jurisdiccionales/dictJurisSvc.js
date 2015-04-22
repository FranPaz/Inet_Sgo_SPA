inetApp.service('dictJurisSvc', function ($rootScope) {

    //#region Datos Basicos Dictamen
    var infoDictamen = {}; //variable global donde voy a guardar la escuela seleccionada al crear el dictamen institucional
    var addInfoDictamen = function (newObj) {
        infoDictamen = newObj;
    }
    //#endregion

    //#region Lineas Jurisdiccionales
    var lineasJurisdiccionales = [];
    var addLineaJuris = function (newObj) {
        lineasJurisdiccionales.push(newObj);
    }

    var addDetallesLinea = function (i, lineaActualizada) {//funcion donde voy a ir actualizando cada linea con los detalles que voy cargando
        lineaActualizada.cantDetalles++;
        lineasJurisdiccionales[i] = lineaActualizada;
    }
    //#endregion

    //#region refresh de Lineas Jurisdiccionales con sus detalles
    var refreshListLineasJuris = function () {
        $rootScope.$broadcast('refreshLineasJuris');
    };
    //#endregion

    return {
        getInfoDictamen: function () {//devuelve la info basica del dictamen
            return infoDictamen;
        },
        addInfoDictamen: addInfoDictamen,
        getLineaJuris: function (i) { //devuelve una linea jurisdiccional en particular, se usa en el alta de las lineas y sus detalles de dictamens jurisdiccionales
            return lineasJurisdiccionales[i];
        },
        getLineasJuris: function () {//devuelve todas la lineas jurisdiccionales
            return lineasJurisdiccionales;
        },
        addLineaJuris: addLineaJuris,
        addDetallesLinea: addDetallesLinea,
        refreshListLineasJuris: refreshListLineasJuris
    };
});