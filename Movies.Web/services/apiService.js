(function () {

    var app = angular.module("moviesApp");

    app.service("apiService", ["$http", function ($http) {

        this.get = function (url, data, success, failure) {
            $http.get(url, data)
                    .then(function (result) {
                        if (!result.data.IsSuccess && !result.data.IsApplicationError) {
                            failure(result.data.ErrorMessage);
                        }
                        else {
                            success(result.data);
                        }
                    }, function (error) {
                        if (failure != null) {
                            failure(error);
                        }
                    });


        };
        this.post = function (url, data, success, failure) {
            $http.post(url, data)
                    .then(function (result) {
                        if (!result.data.IsSuccess && !result.data.IsApplicationError) {
                            failure(result.data.ErrorMessage);
                        }
                        else {
                            success(result.data);
                        }
                    }, function (error) {
                        if (failure != null) {
                            failure(error);
                        }
                    });


        };

    }]);

}());