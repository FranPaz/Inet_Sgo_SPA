inetApp.factory('adminRedDataFactory', function ($resource) {
    return $resource('api/AdministradorDeReds/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});