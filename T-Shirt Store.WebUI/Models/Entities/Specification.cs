﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class Specification : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductSpecification> Specifications { get; set; }
    }

}
