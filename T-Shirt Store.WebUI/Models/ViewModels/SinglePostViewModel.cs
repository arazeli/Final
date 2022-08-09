using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Models.ViewModels
{
    public class SinglePostViewModel
    {
        public BlogPost Post { get; set; }
        public IEnumerable<BlogPost> RelatedPosts { get; set; } 
    }
}
