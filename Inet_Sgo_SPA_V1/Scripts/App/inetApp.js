
//var inetApp = angular.module('inetApp',['ngRoute', 'ngResource', 'ui.router', 'ngCookies','ui.bootstrap','chieffancypants.loadingBar', 'ngAnimate',
//  'ngSanitize'])
var inetApp = angular.module('inetApp', ['ngRoute', 'ngResource', 'ui.router', 'ngCookies', 'ui.bootstrap',
  'ngSanitize'])
//.config(function ($stateProvider, $urlRouterProvider, cfpLoadingBarProvider) {
    .config(function ($stateProvider, $urlRouterProvider) {

        //cfpLoadingBarProvider.includeSpinner = true;

        $urlRouterProvider.otherwise("/Escuelas")

        $stateProvider //fpaz: defino los states que van a guiar el ruteo de las vistas parciales de la app       

        //#region Escuelas
          .state('escuelas', {
              url: "/Escuelas",                  
              views: {
                  'headerAdmin': {
                      templateUrl: '/Scripts/App/Dashboard/Partials/Header.html',
                      controller: ''
                  },
                  'menuAdmin': {
                      templateUrl: '/Scripts/App/Dashboard/Partials/Menu.html',
                      controller: ''
                  },
                  'content': {
                      templateUrl: '/Scripts/App/Dashboard/Partials/Content.html',
                      controller: ''
                  }
              }
          })
        //#endregion     
    })