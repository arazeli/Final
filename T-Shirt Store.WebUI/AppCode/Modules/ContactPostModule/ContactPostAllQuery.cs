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
    public class ContactPostAllQuery : IRequest<IEnumerable<ContactPost>>
    {
      
        public class ContactPostAllQueryHandler : IRequestHandler<ContactPostAllQuery, IEnumerable<ContactPost>> 
        {
            readonly T_Shirt_StoreDbContext db;
            public ContactPostAllQueryHandler(T_Shirt_StoreDbContext db)
            {
                this.db = db;
            }

            public async Task<IEnumerable<ContactPost>> Handle(ContactPostAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ContactPosts.ToListAsync(cancellationToken);
                return data;
            }
        }
    }
}
