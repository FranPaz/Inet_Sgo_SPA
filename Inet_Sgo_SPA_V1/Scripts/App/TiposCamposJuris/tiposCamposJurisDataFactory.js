inetApp.factory('tiposCamposJurisDataFactory', function ($resource) {
    return $resource('api/TipoCampoJurisdiccionals/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});