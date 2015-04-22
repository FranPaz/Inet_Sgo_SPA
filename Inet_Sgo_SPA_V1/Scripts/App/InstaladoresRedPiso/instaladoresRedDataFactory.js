inetApp.factory('instaladoresRedDataFactory', function ($resource) {
    return $resource('api/InstaladoresRed/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});