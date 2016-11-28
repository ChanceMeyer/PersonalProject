//namespace PersonalProject {
//    export class ProfileController {

//        public user;
//        public posts;
//        constructor(private ProfileService: PersonalProject.Services.ProfileService,
//            private $stateParams: ng.ui.IStateParamsService,
//            private $state: angular.ui.IStateParamsService,
//            private accountService: PersonalProject.Services.AccountService,
//            private $scope: ng.IScope) {
//            this.getUserById();
//            this.getPosts();
//        }
//        public getPosts() {
//            this.posts = this.getPosts();
//        }
//        public isLoggedIn()
//        {
//            return this.accountService.isLoggedIn();
//        }
//        private getUserById() {
//            this.ProfileService.getUserById(this.isLoggedIn()).then((data) => {
//                console.log(this.user);
//                this.user = data;
//                console.log(data);
//            }).catch(() => {
//                console.log("this doesnt work");
//            });
//        }
//    }
//}