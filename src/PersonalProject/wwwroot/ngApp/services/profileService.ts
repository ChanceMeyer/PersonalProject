namespace PersonalProject.Services {
    export class ProfileService {
        private profileResource;

        constructor(private $resource: angular.resource.IResourceService) {
            this.profileResource = this.$resource('api/addpost/:id');
            //,{
            //    getUser: {
            //        method: 'GET',
            //        url: '/api/GetUser/{id}',

            //    }
            //    });
        }

        public getUserById(id) {
            var user = this.profileResource.get({ id: id }).$promise;
            return user;
        }

        public getUserInfo() {
            return this.profileResource.getUserInfo();
        }

        public saveProfile(profileToSave) {
            return this.profileResource.save(profileToSave).$promise;
        }

        public getPosts() {
            return this.profileResource.query();
        }
    }
    angular.module('PersonalProject').service('ProfileService', ProfileService);
    

    
}