using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.AppCode.infrastructure;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI.AppCode.Modules.BrendModule
{
    public class BrandRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int Id { get; set; }
        public class BrandRemoveCommandHandler : IRequestHandler<BrandRemoveCommand, CommandJsonResponse>
        {
            readonly T_Shirt_StoreDbContext db;
            
            public BrandRemoveCommandHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;
               

            }
            public async Task<CommandJsonResponse> Handle(BrandRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands.
                  FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByID == null, cancellationToken);

                if (entity == null)
                {
                    return new CommandJsonResponse(true, "Qeyd movcud deyil");
                }

               
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);


                return new CommandJsonResponse(false, "Qeyd silindi");

            }
        }

    }
}