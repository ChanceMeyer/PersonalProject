using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalProject.Models
{
    public class AddPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }

    }
}
