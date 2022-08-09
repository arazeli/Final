
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.AppCode.infrastructure;
using T_Shirt_Store.WebUI.Models.DataContexts;

namespace T_Shirt_Store.WebUI.AppCode.Modules.SubscribeModule
{
    public class SubscribeConfirmCommand : IRequest<CommandJsonResponse>
    {
        public string Token { get; set; }


        public class SubscribeConfirmCommandHandler : IRequestHandler<SubscribeConfirmCommand, CommandJsonResponse>
        {
            readonly T_Shirt_StoreDbContext db;
            readonly IActionContextAccessor ctx;

            public SubscribeConfirmCommandHandler(T_Shirt_StoreDbContext db, IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<CommandJsonResponse> Handle(SubscribeConfirmCommand request, CancellationToken cancellationToken)
            {
                if (string.IsNullOrWhiteSpace(request.Token))
                {
                    ctx.AddModelError("Token", "Token Boshdur");
                    goto l1;
                }
                request.Token = request.Token.Decrypt();

                var match = Regex.Match(request.Token, @"(?<id>\d+)-(?<email>.*)");

                if (!match.Success)
                {
                    ctx.AddModelError("Token", "Token Zedelenib");
                    goto l1;
                }

                int id = Convert.ToInt32(match.Groups["id"].Value);
                string email = match.Groups["email"].Value;

                var subscribe = await db.Subscribes.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

                if (subscribe == null)
                {
                    ctx.AddModelError("Token", "Qeyd Tapilmadi");
                    goto l1;
                }
                else if (!email.Equals(subscribe.Email))
                {
                    ctx.AddModelError("Token", "Token Zedelenib");
                    goto l1;
                }

                subscribe.AppliedDate = DateTime.UtcNow.AddHours(4);

                await db.SaveChangesAsync(cancellationToken);

                return new CommandJsonResponse(false, "Ugurla Tamamlandi");

            l1:
                return new CommandJsonResponse(true, ctx.GetError());

            }
        }
    }
}
