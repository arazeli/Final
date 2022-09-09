using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Modules.BrendModule;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
   
        readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
          
            this.mediator= mediator;
        }

        [Authorize(Policy = "admin.brands.index")]
        public async Task<IActionResult> Index()
        {
            var data = await mediator.Send(new BrandsAllQuery());
            return View(data);
        }

        [Authorize(Policy = "admin.brands.details")]
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            var entity = await  mediator.Send(query);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Create()
        {
           
            return View();
        }
        
        [HttpPost]
        [Authorize(Policy = "admin.brands.create")]
        public async Task<IActionResult> Create(BrandCreatCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

               return RedirectToAction(nameof(Index));
            }
            
            return View(command);
        }

        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {
            var entity = await mediator.Send(query);
            if (entity == null)
            {
                return NotFound();
            }
            var command = new BrandEditCommand();

            command.Id = entity.Id;
            command.Name = entity.Name;  

            return View(command);
        }

        [HttpPost]
        [Authorize(Policy = "admin.brands.edit")]
        public async Task<IActionResult> Edit([FromRoute]int id,BrandEditCommand command)
        {
            if(id != command.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }





        [HttpPost]
        [Authorize(Policy = "admin.brands.delete")]
        public async Task<IActionResult> Delete(BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
           
        }

       
    }
}
