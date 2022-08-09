﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.infrastructure;

namespace T_Shirt_Store.WebUI.Models.Entities
{
    public class ProductSize : BaseEntity
    {
        
        public string ShortName {get; set;}
        public string Name { get; set; }
    }
}