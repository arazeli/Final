using FluentValidation;

namespace T_Shirt_Store.WebUI.AppCode.Modules.ProductModule.Validators
{
    public class ProductEditValidator : AbstractValidator<ProductEditCommand>
    {
        public ProductEditValidator()
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
                .ChildRules(cp =>
                {
                    cp.RuleFor(cpi => cpi.Value)
                    .NotEmpty()
                    .WithMessage("Bos buraxila bilmez");
                });
        }
    }
}
