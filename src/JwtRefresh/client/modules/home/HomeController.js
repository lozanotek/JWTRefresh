(function () {
    var home = angular.module("home");

    home.controller("HomeController",
		["$scope", "messageService",
            function ($scope, messageService) {
                $scope.message = "";

                $scope.loadMessage = function () {
                    messageService.getMessage().then(function (response) {
                        $scope.message = response.data;
                    });
                };

                $scope.loadMessage();
            }]);
})();
