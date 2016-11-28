using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PersonalProject.Models;
using PersonalProject.Interfaces;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonalProject.Controllers
{
    [Route("api/[controller]")]
    public class AddPostController : Controller
    {
        private IAddPostService _service;
        private UserManager<ApplicationUser> _manager;
        // GET: api/values
        [HttpGet]
        public IEnumerable<AddPost> Get()
        {
            return _service.GetAllAddPosts();
        }

        // GET api/values/
        [HttpGet("{id}")]
        public AddPost Get(int id)
        {
            return _service.GetAddPostById(id);
        }

        //[HttpGet("GetUser/{userName}")]
        //public IActionResult GetUser(string userName)
        //{
        //    //var list = _service.GetUserByUserName(userName);
        //    //return Ok(list);
        //}


        //// POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AddPost post)
        {
            var postToReturn =  _service.SaveAddPost(this.User, post);
            return Ok(postToReturn);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteAddPost(id);
            return Ok();
        }

        public AddPostController(IAddPostService service, UserManager<ApplicationUser> manager)
        {
            this._service = service;
            this._manager = manager;
        }
        
    }
}
