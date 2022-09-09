using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.BrendModule
{
    public class BrandCreatCommand : IRequest<Brand>

    {
        public string Name { get; set; }

        public class BrandCreatCommandHandler : IRequestHandler<BrandCreatCommand, Brand>
        {
            readonly T_Shirt_StoreDbContext db;
            
            public BrandCreatCommandHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;
               

            }

            public async Task<Brand> Handle(BrandCreatCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand();

                brand.Name = request.Name;
               

                await db.Brands.AddAsync(brand);

                await db.SaveChangesAsync(cancellationToken);

                return brand;
            }
        }
    }
}