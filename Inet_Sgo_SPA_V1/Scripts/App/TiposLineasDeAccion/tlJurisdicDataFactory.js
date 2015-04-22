inetApp.factory('tlJurisdicDataFactory', function ($resource) {
    return $resource('api/TipoLineasJurisdiccionales/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});