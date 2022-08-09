using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ContactPostModule
{
    public class ContactPostAnswerCommand : IRequest<ContactPost>
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Bos buraxila bilmez")]
        [MinLength(3, ErrorMessage = "3 sinvoldan az ola bilmez")]
        public string AnswerMessage { get; set; }
        public class ContactPostAnswerCommandHandler : IRequestHandler<ContactPostAnswerCommand, ContactPost>
        {
            readonly T_Shirt_StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IConfiguration configuration;

            public ContactPostAnswerCommandHandler(T_Shirt_StoreDbContext db,IActionContextAccessor ctx, IConfiguration configuration) 
            {
                this.db = db;
                this.ctx = ctx;
                this.configuration = configuration;
            }

            public async Task<ContactPost> Handle(ContactPostAnswerCommand request, CancellationToken cancellationToken)
            {
                
              l1:

                if (!ctx.ModelIsValid())
                {

                    return new ContactPost
                    {
                        Id = request.Id,
                        AnswerMessage = request.AnswerMessage
                    };
                  
                }

                var post = await db.ContactPosts.FirstOrDefaultAsync(cp => cp.Id == request.Id, cancellationToken);

                if (post == null)
                {
                    ctx.AddModelError("AnswerMessage", "Tapilmadi");
                    goto l1;
                }
                else if(post.AnswerDate != null)
                {
                    ctx.AddModelError("AnswerMessage", "artiq cavablandirilib");
                }

               
                post.AnswerDate = DateTime.UtcNow.AddHours(4);
                post.AnswerMessage = request.AnswerMessage;

                var emailSuccess = configuration.SendMail(post.Email,
                    "Size gonderilen linke girin",
                    request.AnswerMessage,
                    cancellationToken);

                if (emailSuccess == true)
                {
                   
                    await db.SaveChangesAsync(cancellationToken);
                   
                }

                else
                {
                    ctx.AddModelError("message","Texniki xeta");
                }

                return post;
            }
        }
           
    }
}
