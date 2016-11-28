namespace PersonalProject.Controllers {

    export class HomeController {

    }


    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class DashController {
        public posts;
        public PostResource;

        constructor($state: angular.ui.IStateService, $http: ng.IHttpService,
            public $resource: angular.resource.IResourceService,
            private accountService: PersonalProject.Services.AccountService
        ) {
            this.PostResource = this.$resource('/api/addpost');
            this.getPosts();
        }

        public getPosts() {
            this.posts = this.PostResource.query();
        }
        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }
    }

    //Add Post Controller
    export class AddPostController {
        public post;
        public Postresource;

        public save() {
            this.Postresource.save(this.post).$promise.then(() => {
                this.post = null;
                this.$state.go('dash');

            });
        }

        constructor(private $state: angular.ui.IStateService, $http: ng.IHttpService, private $resource:
            angular.resource.IResourceService) {
            this.Postresource = this.$resource('/api/addpost/:id');
        }
    }
    //Edit post controller
    export class EditPostController {
        public post;
        public Postresource;
        //get a post for editing
        public getPost(id: number) {
            this.post = this.Postresource.get({ id: id })
        }
        //Post the movie after making changes
        public savePost() {
            this.Postresource.save(this.post).$promise.then(() => {
                this.post = null;
                this.$state.go('dash');
            })
        }
        constructor(private $resource: angular.resource.IResourceService,
            public $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {

            this.Postresource = this.$resource('/api/addpost/:id')
            this.getPost($stateParams['id'])
        }
    }
    //Delete a post controller
    export class DeletePostController {
        public post;
        public Postresource;

        public getPost(id: number) {
            this.post = this.Postresource.get({ id: id })
        }

        public deletePost() {
            this.Postresource.delete({ id: this.post.id }).$promise.then(() => {
                this.deletePost = null;
                this.$state.go('dash');
            })
        }
        constructor(private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: ng.ui.IStateService) {
            this.Postresource = $resource('/api/addpost/:id');
            this.getPost($stateParams['id']);
        }
    }

    export class ProfileController {
        //constructor(private accountService: PersonalProject.Services.AccountService) {
        //    this.getUserName();
        //}
        //public isLoggedIn() {
        //    return this.accountService.isLoggedIn();
        //}
        //public getUserName() {
        //    return this.accountService.getUserName();
        //}

        public Postresource;
        public user;
        public posts;
        constructor(
            private $resource: angular.resource.IResourceService,
            private $stateParams: ng.ui.IStateParamsService,
            private $state: angular.ui.IStateParamsService,
            private accountService: PersonalProject.Services.AccountService,
            private $scope: ng.IScope) {
            this.Postresource = $resource('/api/addpost/:id', null, {
                getById: {
                    method: 'GET',
                    url: '/api/GetUser/:id',
                    isArray: true
                }

            });

            this.getUserById();
        }
        public getUserById() {
            this.user = this.Postresource.get(this.isLoggedIn());

        }
        public isLoggedIn() {
            return this.accountService.isLoggedIn();
        }
    }
}