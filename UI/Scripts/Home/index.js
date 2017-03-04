var apiBaseAddress = "http://arintahmasian.com/api";

(function () {


    var app = angular.module("MyCleanSolution", []).filter('utcToLocal', Filter);
    

    function Filter($filter) {
        return function (utcDateString, format) {
            // return if input date is null or undefined
            if (!utcDateString) {
                return;
            }

            // append 'Z' to the date string to indicate UTC time if the timezone isn't already specified
            if (utcDateString.indexOf('Z') === -1 && utcDateString.indexOf('+') === -1) {
                utcDateString += 'Z';
            }

            // convert and format date using the built in angularjs date filter
            return $filter('date')(utcDateString, format);
        }
    };

    var AccountController = function ($scope, $http, $log) {
       
        
        $scope.error = "";
        $scope.message = "this is a test";

        $scope.loginCredentials = {
            Username: "Arin",
            Password: "test"
        };


        $scope.activeSession = {
            Token: "",
            DateInitiated: "",
            DateLastrUsed: ""
        };

        $scope.ClearToken = function () {
            $scope.activeSession.Token = "";
        };
      
        $scope.login = function () {
            
            var req = {
                method: 'POST',
                url: apiBaseAddress + "/account/Login",
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
                ,
                data: $.param($scope.loginCredentials) // $.param({ Username: $scope.loginCredentials.Username, Password: $scope.loginCredentials.Password } )
            }

            $http(req).then(function (response) {
                $log.info(response);
                $scope.activeSession = response.data;
                $scope.error = "";

            }, function (reason) {
                $log.error(reason);
                $scope.error = "Please try again.";
            });
        };

       

    };

    app.controller("AccountController",["$scope","$http", "$log", AccountController]);

}());



