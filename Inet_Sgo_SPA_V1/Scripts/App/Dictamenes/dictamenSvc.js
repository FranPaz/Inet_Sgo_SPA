inetApp.service('dictamenSvc', function (dictInstDataFactory, dictJurisDataFactory, $rootScope) {
    
    //#region refresh de Dictamenes Institucionales
    var refreshListDictamenInst = function () {        
        broadcastDictamenesInst();
    };
    
    var broadcastDictamenesInst = function () {
        $rootScope.$broadcast('refreshDictInst');    
    };
    //#endregion

    //#region refresh de Dictamenes Jurisdiccionales
    var refreshListDictamenJuris = function () {
        broadcastDictamenesJuris();
    };

    var broadcastDictamenesJuris = function () {
        $rootScope.$broadcast('refreshDictJuris');
    };
    //#endregion

    return {        
        refreshListDictamenInst: refreshListDictamenInst,
        refreshListDictamenJuris: refreshListDictamenJuris,

        getListDictamenesInst: function () {//devuelve la info basica del dictamen
            return dictInstDataFactory.query();
        },

        getListDictamenesJuris: function () {//devuelve la info basica del dictamen
            return dictJurisDataFactory.query();
        }
    };
});