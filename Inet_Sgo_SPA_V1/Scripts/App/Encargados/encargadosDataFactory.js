inetApp.factory('encargadosDataFactory', function ($resource) {
    return $resource('api/Encargados/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});