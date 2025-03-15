
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Extensions;
using Shop.Application.Features.Products.Queries.GetAllProduct;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;

namespace Shop.Application.Features.Products.Queries.GetProductsWithPagination
{
    public class GetProductsWithPaginationQuery : IRequest<PaginatedResult<GetProductsWithPaginationDto>>
    {
        public GetProductsWithPaginationQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedResult<GetProductsWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<PaginatedResult<GetProductsWithPaginationDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Product>()
                            .Entities
                            .AsNoTracking()
                            .ProjectToType<GetProductsWithPaginationDto>()
                            .ToPaginatedListAsync(request.Page, request.PageSize, cancellationToken);
        }
    }
}
