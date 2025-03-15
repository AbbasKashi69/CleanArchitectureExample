
using FluentValidation;

namespace Shop.Application.DTOs.CategoryDto.Validators
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("نام نباید خالی باشد.")
                .NotNull()
                .WithMessage("نام نباید خالی باشد.");

        }
    }
}
