using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using PersonalProject.Models;

namespace PersonalProject.Interfaces
{
    public interface IAddPostService
    {
        void DeleteAddPost(int id);
        AddPost GetAddPostById(int id);
        IList<AddPost> GetAllAddPosts();
        object GetUser(string id, string uid);
        Task SaveAddPost(IPrincipal user, AddPost post);
    }
}