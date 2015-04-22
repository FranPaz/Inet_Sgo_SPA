inetApp.factory('dictInstDataFactory', function ($resource) {
    return $resource('api/DictamenInstitucional/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});