

using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.DTOs.CategoryDto;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Categories.Queries
{
    public class GetAllCategoriesQuery : IRequest<List<GetAllCategoryDto>>
    {

    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<GetAllCategoryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllCategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Category>()
                .Entities
                .OrderBy(d=> d.Name)
                .ProjectToType<GetAllCategoryDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
