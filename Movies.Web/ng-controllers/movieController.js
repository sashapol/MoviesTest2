(function () {

    var app = angular.module("moviesApp");

    app.controller("movieController", ["$scope", function ($scope) {

        $scope.movie = "movieee";
    }]);

}());