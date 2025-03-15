

using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductQuery : IRequest<List<GetAllProductDto>>
    {
    }

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Product>()
                .Entities
                .AsNoTracking()
                .ProjectToType<GetAllProductDto>()
                .ToListAsync(cancellationToken);
        }
    }
}
