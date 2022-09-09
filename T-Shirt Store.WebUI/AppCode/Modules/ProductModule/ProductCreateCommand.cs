using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using T_Shirt_Store.WebUI.AppCode.Extensions;
using T_Shirt_Store.WebUI.Models.DataContexts;
using T_Shirt_Store.WebUI.Models.Entities;
using me = T_Shirt_Store.WebUI.Models.Entities;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ProductModule
{
    public class ProductCreateCommand : IRequest<ProductCreateCommandResponse>
    {
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

        public SpecificationKeyValue[] Specifications {get;set;}
        public ProductPricing[] Pricing { get; set; }
        public ImageItem[] Images { get; set; }

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductCreateCommandResponse>
        {
            readonly T_Shirt_StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            readonly IValidator<ProductCreateCommand> validator;
            public  ProductCreateCommandHandler(T_Shirt_StoreDbContext db,
                IActionContextAccessor ctx,
                IWebHostEnvironment env,
                IValidator<ProductCreateCommand> validator)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
                this.validator = validator;
            }
            public async Task<ProductCreateCommandResponse> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                var result= validator.Validate(request);



                if (!result.IsValid)
                {
                    var response = new ProductCreateCommandResponse
                    {
                        Product = null,
                        ValidationResult = result
                    };

                    return response;

                }
                //if (!ctx.ModelIsValid())
                //{
                //    return null;
                //}

                var product = new Product();

                product.Name = request.Name;
                product.StockKeepingUnit = request.StockKeepingUnit;
                product.BrandId = request.BrandId;
                product.CategoryId = request.CategoryId;
                product.ShortDescription = request.ShortDescription;
                product.Description = request.Description;

                if (request.Specifications !=null && request.Specifications.Length > 0)
                {
                    product.Specifications = new List<ProductSpecification>();

                    foreach (var spec in request.Specifications)
                    {
                        product.Specifications.Add(new ProductSpecification { 
                           SpecificationId = spec.Id,
                           Value = spec.Value
                        });
                    }
                }

                if (request.Images != null && request.Images.Any(i => i.File != null))
                {
                    product.Images = new List<ProductImage>();

                    foreach (var productFile in request.Images.Where(i => i.File != null))
                    {

                        string fileExtension = Path.GetExtension(productFile.File.FileName);

                        string name2 = $"product-{Guid.NewGuid()}{fileExtension}";

                        string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", name2);

                        using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                        {
                            await productFile.File.CopyToAsync(fs);
                        }

                        //string name = productFile.File.FileName;
                        //string name2 = await env.SaveFile(productFile.File, cancellationToken, "product");
                        product.Images.Add(new ProductImage
                        {
                            ImagePath = name2,
                            IsMain = productFile.IsMain
                        
                        });
                    }
                }
                else
                {
                    ctx.AddModelError("Images", "Sekil qeyd edilmeyib");
                    goto l1;
                }


                if (request.Pricing != null && request.Pricing.Length > 0)
                {
                    product.Pricings = new List<me.ProductPricing>();

                    foreach (var pricing in request.Pricing)
                    {
                        product.Pricings.Add(new me.ProductPricing 
                        { 
                            ColorId=pricing.ColorId,
                            SizeId = pricing.SizeId,
                            Price = pricing.Price
                        });

                    }
                }

                await db.Products.AddAsync(product,cancellationToken);

                await db.SaveChangesAsync(cancellationToken);

                try
                {
                    var response = new ProductCreateCommandResponse
                    {
                        Product = product,
                        ValidationResult = result
                    };

                    return response;
                }
                catch(Exception ex)
                {
                    var response = new ProductCreateCommandResponse
                    {
                        Product = product,
                        ValidationResult = result
                    };

                    response.ValidationResult.Errors.Add(new ValidationFailure("Name", "Xeta bas verdi"));

                    return response;
                }

            l1:
                return null;
            }
        }
    }

    

   

   


    public class ProductCreateCommandResponse
    {
        public Product Product { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}


