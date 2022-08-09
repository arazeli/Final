using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class Faq : BaseEntity
    {
        
        public string Question { get; set; }
        public string  Answer { get; set; }
    }
}
