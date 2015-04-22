inetApp.factory('camposProgDataFactory', function ($resource) {
    return $resource('api/CampoProgramaticoes/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});