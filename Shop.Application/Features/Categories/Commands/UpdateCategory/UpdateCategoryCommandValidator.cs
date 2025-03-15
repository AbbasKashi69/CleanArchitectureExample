

using FluentValidation;
using Shop.Application.Features.Categories.Commands.UpdateCategory;

namespace Shop.Application.Features.Categories.Commands.CreateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("نام اجباری است.")
                .NotNull()
                .WithMessage("نام اجباری است.");
        }
    }
}
