inetApp.factory('dictRedesPisoInetDataFactory', function ($resource) {
    return $resource('api/DictJurisAdminPisoInternet/:id',
           { id: '@id' },
           { 'update': { method: 'PUT' } }
        );
});