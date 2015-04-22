inetApp.factory('escuelasDataFactory', function ($resource) {
    return $resource('api/Escuelas/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});