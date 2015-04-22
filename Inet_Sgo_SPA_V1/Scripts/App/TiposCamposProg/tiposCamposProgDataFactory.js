inetApp.factory('tiposCamposProgDataFactory', function ($resource) {
    return $resource('api/TipoCampoProgramaticoes/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});