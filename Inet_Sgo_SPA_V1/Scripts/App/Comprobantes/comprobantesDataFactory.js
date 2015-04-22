inetApp.factory('comprobantesDataFactory', function ($resource) {
    return $resource('api/TipoComprobantes/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});