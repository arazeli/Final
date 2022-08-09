using MediatR;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using T_Shirt_Store.WebUI.AppCode.infrastructure;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules
{


    public class SubscribeCreateCommand : IRequest<CommandJsonResponse>
    {
        [Required(ErrorMessage = "Bosh buraxmag olmaz")]
        [EmailAddress(ErrorMessage = " E poct uygun deil")]

        public string Email { get; set; }


        public class SubscribeCreateCommandHandler : IRequestHandler<SubscribeCreateCommand, CommandJsonResponse>
        {
            readonly T_Shirt_StoreDbContext db;
            readonly IConfiguration configuration;
            readonly IActionContextAccessor ctx;

            public SubscribeCreateCommandHandler(T_Shirt_StoreDbContext db, IConfiguration configuration, IActionContextAccessor ctx)
            {
                this.db = db;
                this.configuration = configuration;
                this.ctx = ctx;

            }
            public async Task<CommandJsonResponse> Handle(SubscribeCreateCommand request, CancellationToken cancellationToken)
            {
              

                var subscribe = await db.Subscribes.FirstOrDefaultAsync(s => s.Email.Equals(request.Email), cancellationToken);

                if (subscribe == null)
                {
                    subscribe = new Subscribe();
                    subscribe.Email = request.Email;

                    await db.Subscribes.AddAsync(subscribe, cancellationToken);

                    await db.SaveChangesAsync(cancellationToken);
                }
                else if (subscribe.EmailSended == true)
                {
                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "Artig Abunesiniz"
                    };

                }

                string token = $"{subscribe.Id}-{subscribe.Email}".Encrypt();
                string link = $"{ ctx.GetAppLink()}/subscribe-confirm?token={token}";

                var emailSuccess = configuration.SendMail(subscribe.Email, "Size gonderilen linke girin", $"Please confirm subscription with <a href=\"{link}\">link</a>", cancellationToken);

                if (emailSuccess == true)
                {
                    subscribe.EmailSended = true;

                    await db.SaveChangesAsync(cancellationToken);
                }

                else
                {
                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "Texniki Xeta Bash verdi"
                    };
                }




                return new CommandJsonResponse
                {
                    Error = false,
                    Message = $"tamamlamaq ucun {subscribe.Email}-e baxin"
                };








            }
        }
    }

}
