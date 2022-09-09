using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Modules;
using T_Shirt_Store.WebUI.AppCode.Modules.SubscribeModule;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly T_Shirt_StoreDbContext db;
        readonly IMediator mediator;
        public HomeController(T_Shirt_StoreDbContext db, IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator; 

        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactPost model)
        {
            if(!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = ModelState.SelectMany(ms=>ms.Value.Errors).First().ErrorMessage
                });
            }

            await db.ContactPosts.AddAsync(model);
            await db.SaveChangesAsync();
            return Json(new { 
            error =false,
            message="Muracietiniz qeyde alindi.5 is gunu erzinde elaqe saxlanilacaq"
            });
            
        }




        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateCommand command) 
        {
            var response = await mediator.Send(command);

            return Json(response);
        }


        [HttpGet]
        [Route("/subscribe-confirm")]
        public async Task<IActionResult> SubscribeConfirm(SubscribeConfirmCommand command)
        {
            var response = await mediator.Send(command);

            return View(response);
        }










    }
}
