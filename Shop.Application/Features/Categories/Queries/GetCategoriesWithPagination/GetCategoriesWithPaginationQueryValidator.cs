

using FluentValidation;

namespace Shop.Application.Features.Categories.Queries.GetCategoriesWithPagination
{
    public class GetCategoriesWithPaginationQueryValidator : AbstractValidator<GetCategoriesWithPaginationQuery>
    {
        public GetCategoriesWithPaginationQueryValidator()
        {
            RuleFor(r => r.Page)
                 .GreaterThanOrEqualTo(1)
                 .WithMessage("Page at least greater than or equal to 1.");

            RuleFor(r => r.PageSize)
                .GreaterThanOrEqualTo(1)
                .WithMessage("PageSize at least greater than or equal to 1.");
        }
    }
}
