

using FluentValidation;

namespace Shop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommnadValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommnadValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("نام اجباری است.")
                .NotNull()
                .WithMessage("نام اجباری است.");

            RuleFor(r => r.Price)
                .GreaterThanOrEqualTo(0)
                .WithMessage("قیمت محصول اشتباه وارد شده است.");
        }
    }
}
