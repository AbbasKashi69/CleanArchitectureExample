using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Numerics;
using Shop.Application.DTOs.CategoryDto;
using MapsterMapper;
using Mapster;
using Shop.Application.Extensions;

namespace Shop.Application.Features.Categories.Queries
{
    public class GetCategoriesWithPaginationQuery : IRequest<PaginatedResult<GetCategoriesWithPaginationDto>>
    {
        public GetCategoriesWithPaginationQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, PaginatedResult<GetCategoriesWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriesWithPaginationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResult<GetCategoriesWithPaginationDto>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Category>()
                .Entities
                .OrderBy(x => x.Name)
                .ProjectToType<GetCategoriesWithPaginationDto>()
                .ToPaginatedListAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
