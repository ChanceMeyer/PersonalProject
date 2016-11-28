namespace PersonalProject {

    angular.module('PersonalProject', ['ui.router', 'ngResource', 'ui.bootstrap']).config((
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider
    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: '/ngApp/views/home.html',
                controller: PersonalProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: PersonalProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: PersonalProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: PersonalProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: PersonalProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: PersonalProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            })
            .state('dash', {
                url: '/dash',
                templateUrl: '/ngApp/views/dash.html',
                controller: PersonalProject.Controllers.DashController,
                controllerAs: 'controller'
            })
            .state('addPost', {
                url: '/AddPost',
                templateUrl: '/ngApp/views/AddPost.html',
                controller: PersonalProject.Controllers.AddPostController,
                controllerAs: 'controller'
            })
            .state('editPost', {
                url: '/editPost/:id',
                templateUrl: '/ngApp/views/editPost.html',
                controller: PersonalProject.Controllers.EditPostController,
                controllerAs: 'controller'
            })
            .state('deletePost', {
                url: '/deletePost/:id',
                templateUrl: '/ngApp/views/deletePost.html',
                controller: PersonalProject.Controllers.DeletePostController,
                controllerAs: 'controller'
            })
            .state('profile', {
                url: '/profile',
                templateUrl: '/ngApp/views/profile.html',
                controller: PersonalProject.Controllers.ProfileController,
                controllerAs: 'controller'
            })
            .state('progressBar', {
                url: '/progressBar',
                templateUrl: '/ngApp/views/progressBar.html'
            });
            

        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/login');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);
    });

    
    angular.module('PersonalProject').factory('authInterceptor', (
        $q: ng.IQService,
        $window: ng.IWindowService,
        $location: ng.ILocationService
    ) =>
        ({
            request: function (config) {
                config.headers = config.headers || {};
                config.headers['X-Requested-With'] = 'XMLHttpRequest';
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 401 || rejection.status === 403) {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        })
    );

    angular.module('PersonalProject').config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });

    

}
