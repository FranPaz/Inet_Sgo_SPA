inetApp.factory('tiposDetallesJurisDataFactory', function ($resource) {
    return $resource('api/TipoDetalleJurisdiccionals/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});