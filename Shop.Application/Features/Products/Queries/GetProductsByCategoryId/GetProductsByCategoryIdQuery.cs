

using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Features.Products.Queries.GetAllProduct;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetProductsByCategoryId
{
    public class GetProductsByCategoryIdQuery : IRequest<List<GetProductsByCategoryIdDto>>
    {
        public int CategoryId { get; set; }

        public GetProductsByCategoryIdQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }

    public class GetProductsByCategoryIdQueryHandler : IRequestHandler<GetProductsByCategoryIdQuery, List<GetProductsByCategoryIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsByCategoryIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetProductsByCategoryIdDto>> Handle(GetProductsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Product>()
                .Entities
                .AsNoTracking()
                .Where(w=> w.CategoryId == request.CategoryId)
                .ProjectToType<GetProductsByCategoryIdDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
