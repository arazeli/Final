using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactPostSingleQuery : IRequest<ContactPost>
    {
        public int Id { get; set; }
        public class ContactPostSingleQueryHandler : IRequestHandler<ContactPostSingleQuery, ContactPost>
        {
            readonly T_Shirt_StoreDbContext db;
            public ContactPostSingleQueryHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;

            }
            public async Task<ContactPost> Handle(ContactPostSingleQuery request, CancellationToken cancellationToken)
            {
                var model = await db.ContactPosts
                    .FirstOrDefaultAsync(b => b.Id == request.Id,
                    cancellationToken);
                return model;

            }
        }
    }


}
