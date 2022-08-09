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
    public class BrandEditCommand : IRequest<Brand>

    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class BrandEditCommandHandler : IRequestHandler<BrandEditCommand, Brand>
        {
            readonly T_Shirt_StoreDbContext db;
            public BrandEditCommandHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;

            }

            public async Task<Brand> Handle(BrandEditCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands.
                    FirstOrDefaultAsync(b=>b.Id==request.Id && b.DeletedByID==null, cancellationToken);

                if(entity==null)
                {
                    return null;
                }

                entity.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);


                return entity;
            }
        }
    }
}
