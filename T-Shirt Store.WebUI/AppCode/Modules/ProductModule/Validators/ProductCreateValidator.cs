using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ProductModule.Validators
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateCommand>
    {
        public ProductCreateValidator()
        {
            RuleFor(p => p.Name)
              .NotEmpty()
              .NotNull()
              .WithMessage("Bosh buraxila bilmez");

            RuleFor(p => p.ShortDescription).NotEmpty().WithMessage("Bos buraxila bilmez");
            RuleFor(p => p.StockKeepingUnit).NotEmpty().WithMessage("Bos buraxila bilmez");

            RuleFor(p => p.BrandId).GreaterThan(0).WithMessage("Duzgun melumat secilmeyib");
            RuleFor(p => p.CategoryId).GreaterThan(0).WithMessage("Duzgun melumat secilmeyib");

            RuleForEach(p => p.Specifications)
                .ChildRules(cp=>
                {
                    cp.RuleFor(cpi =>cpi.value)
                    .NotEmpty()
                    .WithMessage("Bos buraxila bilmez");
                });
        }
    }
}
