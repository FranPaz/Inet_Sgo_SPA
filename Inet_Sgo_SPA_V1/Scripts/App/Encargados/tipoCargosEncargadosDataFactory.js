inetApp.factory('tipoCargosEncargadosDataFactory', function ($resource) {
    return $resource('api/TipoCargoEncargadoes/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});