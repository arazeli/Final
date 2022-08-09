using MediatR;
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
    public class BrandsAllQuery : IRequest<IEnumerable<Brand>>
    {

        public class BrandsAllQueryHandler : IRequestHandler<BrandsAllQuery, IEnumerable<Brand>>
        {

            readonly T_Shirt_StoreDbContext db;
            public BrandsAllQueryHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;

            }


            public async Task<IEnumerable<Brand>> Handle(BrandsAllQuery request, CancellationToken cancellationToken)
            {
               var model= await db.Brands.Where(b => b.DeletedByID == null).ToListAsync(cancellationToken);
                return model;
            }
        }
    }
}
