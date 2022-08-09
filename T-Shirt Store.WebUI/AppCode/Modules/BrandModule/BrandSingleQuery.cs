﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.BrendModule
{
    public class BrandSingleQuery : IRequest<Brand>
    {
        public int Id { get; set; }
        public class BrandSingleQueryHandler : IRequestHandler<BrandSingleQuery, Brand>
        {
            readonly T_Shirt_StoreDbContext db;
            public BrandSingleQueryHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;

            }
            public async Task<Brand> Handle(BrandSingleQuery request, CancellationToken cancellationToken)
            {
                var model = await db.Brands
                    .FirstOrDefaultAsync(b=>b.Id== request.Id && b.DeletedByID==null,
                    cancellationToken);
                return model;

            }
        }
    }
}
