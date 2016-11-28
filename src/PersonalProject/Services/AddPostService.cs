using Microsoft.AspNetCore.Identity;
using PersonalProject.Interfaces;
using PersonalProject.Models;
using PersonalProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using static PersonalProject.Repositories.GenericRepository;

namespace PersonalProject.Services
{
    public class AddPostService : IAddPostService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;

        // Get all Posts
        public IList<AddPost> GetAllAddPosts()
        {
            var posts = _repo.Query<AddPost>().ToList();
            return posts;
        }
        // Get single post by Id
        public AddPost GetAddPostById(int id)
        {
            return _repo.Query<AddPost>().Where(m => m.Id == id).FirstOrDefault();
        }
        //Get post by UserId
        //public AddPost GetAddPostByUserId()
        //{
        //    return _repo.Query<AddPost>().Where(m => m.UserId = GetAddPostByUserId).FirstOrDefault();
        //}
        //Post single add to Database
        public object GetUser(string id, string uid)
        {
            var data = _repo.Query<ApplicationUser>().Where(u => u.Id == uid).FirstOrDefault();
            if (id == data.UserName)
            {
                id = uid;
            }
            var user = _repo.Query<ApplicationUser>().Where(u => u.Id == id).Select(u => new
            {

                UserName = u.UserName,
                AddPosts = _repo.Query<AddPost>().Where(a => a.UserId == id).ToList()
            }).FirstOrDefault();
            return user;
        }
        public async Task SaveAddPost(IPrincipal user,AddPost post)
        {
            var AppUser = await _manager.FindByNameAsync(user.Identity.Name);
            var userId = AppUser.Id;
            var userName = AppUser.UserName;
            if(post.Id == 0)
            {
                //var newDate = new DateTime.;
                //var netDate = newDate.toISOString();
                var newPost = new AddPost
                {
                    UserId = userId,
                    UserName = userName,
                    Title = post.Title,
                    Location = post.Location,
                    Price = post.Price,
                    //Date = newDate,
                    Discription = post.Discription
                };
                _repo.Add<AddPost>(newPost);
                _repo.SaveChanges();
            }else
            {
                _repo.Update(post);
            }
        }
        //Delete single post from the database
        public void DeleteAddPost(int id)
        {
            AddPost postToDelete = _repo.Query<AddPost>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(postToDelete);
        }
        public AddPostService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            this._manager = manager;
            this._repo = repo;
        }
    }
}
