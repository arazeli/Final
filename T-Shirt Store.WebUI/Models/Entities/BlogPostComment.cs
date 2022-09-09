using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class BlogPostComment : BaseEntity
    {
        public string  Comment { get; set; }
        public int BlogPostId { get; set; }
        public virtual BlogPost BlogPost { get; set; }

        public int? ParentId  { get; set; }
        public virtual BlogPostComment Parent { get; set; }

        public virtual ICollection<BlogPostComment> Children { get; set; }
    }
}
