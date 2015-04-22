inetApp.factory('dictJurisDataFactory', function ($resource) {
    return $resource('api/DictamenesJurisdiccionales/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});