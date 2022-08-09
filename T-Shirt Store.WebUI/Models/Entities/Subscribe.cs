using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class Subscribe : BaseEntity
    {
        public string Email { get; set; }

        public bool EmailSended { get; set; } = false;

        public DateTime? AppliedDate { get; set; }
    }
}
