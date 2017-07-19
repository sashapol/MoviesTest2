(function () {

    var moviesApp = angular.module("moviesApp", ["ngRoute"]);

    moviesApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: 'templates/home.html',
                controller: 'homeController'
            })
        .when('/movie/:id', {
            templateUrl: 'templates/movie.html',
            controller: 'movieController'
        })
        ;


    }]);

}());