﻿using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;
using me = T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ProductModule
{
    public class ProductEditCommand : IRequest<ProductEditCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public SpecificationKeyValue[] Specifications { get; set; }
        public ProductPricing[] Pricing { get; set; }
        public ImageItem[] Images { get; set; }

        public class ProductEditCommandHandler : IRequestHandler<ProductEditCommand, ProductEditCommandResponse>
        {
            readonly T_Shirt_StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            readonly IValidator<ProductEditCommand> validator;
            public ProductEditCommandHandler(T_Shirt_StoreDbContext db,
                IActionContextAccessor ctx,
                IWebHostEnvironment env,
                IValidator<ProductEditCommand> validator)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
                this.validator = validator;
            }
            public async Task<ProductEditCommandResponse> Handle(ProductEditCommand request, CancellationToken cancellationToken)
            {
                var result = validator.Validate(request);

                var response = new ProductEditCommandResponse
                {
                    Product = null,
                    ValidationResult = null
                };


                if (!result.IsValid)
                {
                    response.ValidationResult = result;

                    return response;

                }


                var product = await db.Products
                    .Include(p=>p.Images)
                    .Include(p => p.Specifications)
                     .Include(p => p.Pricings)
                    .FirstOrDefaultAsync(p => p.Id==request.Id,cancellationToken);

                if (product == null)
                {
                    response.ValidationResult = result;


                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Product tapilmadi"));

                    return response;

                }

                product.Name = request.Name;
                product.StockKeepingUnit = request.StockKeepingUnit;
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;





                //if (request.Images != null)
                //{
                //    if (product.Images == null)
                //    {
                //        product.Images = new List<ProductImage>();
                //    }

                //    foreach (var productFile in request.Images)
                //    {
                //        if (productFile.File == null && string.IsNullOrWhiteSpace(productFile.TempPath))
                //        {
                //            var dbProductImage = product.Images.FirstOrDefault(p => p.Id == productFile.Id);

                //            if (dbProductImage != null)
                //            {
                //                dbProductImage.DeletedDate = DateTime.Now;
                //                dbProductImage.DeletedByID = 1;
                //                dbProductImage.IsMain = false;
                //            }
                //        }


                //        else if (productFile != null)
                //        {
                //            string name = await env.SaveFile(productFile.File, cancellationToken, "product");
                //            product.Images.Add(new ProductImage
                //            {
                //                ImagePath = name,
                //                IsMain = productFile.IsMain
                //            });
                //        }

                //        else if (string.IsNullOrWhiteSpace(productFile.TempPath))
                //        {
                //            var dbProductImage = product.Images.FirstOrDefault(p => p.Id == productFile.Id);

                //            if (dbProductImage != null)
                //            {
                //                dbProductImage.IsMain = productFile.IsMain;
                //            }

                //        }

                //    }
                //}
                //else
                //{
                //    ctx.AddModelError("Images", "Sekil qeyd edilmeyib");
                //    goto l1;
                //}


                if (request.Specifications != null && request.Specifications.Length > 0)
                {
                    if (product.Specifications == null) 
                    {
                        product.Specifications = new List<ProductSpecification>();
                    }

                   

                    foreach (var spec in product.Specifications)
                    {

                       var specFromForm = request.Specifications.FirstOrDefault(s=>s.Id==spec.SpecificationId);

                        if (specFromForm ==null || string.IsNullOrWhiteSpace(specFromForm.Value)) 
                        {
                            db.ProductSpecifications.Remove(spec);
                        }

                        else
                        {
                            spec.Value = specFromForm.Value;
                        }
                        
                    }

                    var ids = request.Specifications.Select(s => s.Id)
                        .Except(product.Specifications.Select(s => s.SpecificationId));

                    foreach (var id in ids) 
                    {
                        var spec = request.Specifications.FirstOrDefault(s=>s.Id==id);
                        product.Specifications.Add(new ProductSpecification
                        {
                            SpecificationId = spec.Id,
                            Value = spec.Value
                        });
                    }
                }


                //if (request.Pricing != null && request.Pricing.Length > 0)
                //{
                //    product.Pricings = new List<me.ProductPricing>();

                //    foreach (var pricing in request.Pricing)
                //    {
                //        product.Pricings.Add(new me.ProductPricing
                //        {
                //            ColorId = pricing.ColorId,
                //            SizeId = pricing.SizeId,
                //            Price = pricing.Price
                //        });

                //    }
                //}

                //await db.Products.AddAsync(product, cancellationToken);
                try
                {
                    await db.SaveChangesAsync(cancellationToken);
                    response.Product = product;
                    response.ValidationResult = result;


                    return response;
                }
                catch (Exception ex)
                {
                    response.Product = product;
                    response.ValidationResult = result;

                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Xeta bas verdi"));

                    return response;
                }

            l1:
                return null;
            }
        }
    }

    

    public class ProductEditCommandResponse
    {
        public Product Product { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}


