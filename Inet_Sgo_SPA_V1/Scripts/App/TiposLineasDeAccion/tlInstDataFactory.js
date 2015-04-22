inetApp.factory('tlInstDataFactory', function ($resource) {
    return $resource('api/TipoLineasInstitucionales/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});