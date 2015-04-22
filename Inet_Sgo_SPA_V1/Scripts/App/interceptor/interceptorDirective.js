inetApp.directive('loader', function () {    
    return {
        restrict: 'E',        
        template: '<div ng-show="loading"><img src="../../../../img/bx_loader.gif" class="ajax-loader" /></div>'
    };
})