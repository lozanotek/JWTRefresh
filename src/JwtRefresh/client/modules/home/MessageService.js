(function () {
	var home = angular.module("home");

	home.factory("messageService",
		["$http",
		function ($http) {
		    var service = {};

		    service.getMessage = function() {
		        return $http.get("/api/message");
		    };

		    return service;
		}]);
})();
