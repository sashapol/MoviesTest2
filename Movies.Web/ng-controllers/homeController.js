(function () {
    var app = angular.module("moviesApp");

    app.controller("homeController", ['$scope', '$interval', 'apiService', function ($scope, $interval, apiService) {

        function init() {
            apiService.get('api/Movies/Init', null, initSuccess, null);
            function initSuccess(response) {
                $scope.emptyMovie = response.EmptyMovie;
            }

            $scope.getAllMovies();
            //$interval($scope.getAllMovies, 10000);

        }


        function getAllMovies() {
            apiService.get('api/Movies/GetAllMovies', null, getAllMoviesSuccess, null);
            function getAllMoviesSuccess(response) {
                $scope.moviesList = response.MoviesList;
            }
        }

        function insertMovie(form)
        {
            $scope.errorMessage = "";
            if (!form.$valid)
                return;
            apiService.post('api/Movies/InsertMovie', {Movie: $scope.emptyMovie}, insertMovieSuccess, null);
            function insertMovieSuccess(response) {
                if (response.IsApplicationError) {
                    $scope.errorMessage = response.ErrorMessage;
                }
                else {
                    $scope.getAllMovies();
                    //   $scope.moviesList = response.MoviesList;
                    for (var prop in $scope.emptyMovie) {
                        $scope.emptyMovie[prop] = null;
                    }
                }
            }
        }

        
        $scope.init = init;
        $scope.insertMovie = insertMovie;
        $scope.getAllMovies = getAllMovies;
        $scope.init();

    }]);

}());