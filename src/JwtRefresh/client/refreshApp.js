(function () {

    var refreshApp = angular.module("refreshApp",
			["ngRoute",
			"ngAnimate",
			"angular-jwt",
			"home"]);

    refreshApp.config(["$locationProvider", function ($locationProvider) {
        $locationProvider.hashPrefix("");
    }]);

    //refreshApp.config(function ($httpProvider, jwtInterceptorProvider) {
    //	jwtInterceptorProvider.tokenGetter = function (jwtHelper, $http) {
    //		// This is a promise of a JWT id_token
    //		return $http({
    //			url: "api/token",
    //			// This will not send the JWT for this call
    //			skipAuthorization: true,
    //			method: 'GET',
    //		}).then(function (response) {
    //			var jwt = response.data;
    //			console.log(jwt);

    //			return jwt;
    //		});
    //	};

    //	$httpProvider.interceptors.push("jwtInterceptor");
    //});

    refreshApp.config(function ($httpProvider, jwtOptionsProvider) {
        jwtOptionsProvider.config({
            tokenGetter: ["options", "$http", function (options, $http) {
                // Skip authentication for any requests ending in .html
                if (options.url.substr(options.url.length - 5) === ".html") {
                    return null;
                }

                // This is a promise of a JWT id_token
                return $http({
                    url: "api/token",
                    // This will not send the JWT for this call
                    skipAuthorization: true,
                    method: "POST",
                }).then(function (response) {
                    var jwt = response.data;
                    console.log(jwt);

                    return jwt;
                });
            }]
        });

        $httpProvider.interceptors.push("jwtInterceptor");
    });

    refreshApp.config(["$routeProvider",
		function ($routeProvider) {
		    $routeProvider
				.when("/", {
				    templateUrl: "client/modules/home/home.html",
				    controller: "HomeController"
				})
				.otherwise({
				    redirectTo: "/"
				});
		}]);

    angular.module("home", ["ngRoute"]);
})();
