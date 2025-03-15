
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Features.Products.Queries.GetAllProduct;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<GetProductByIdDto>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetProductByIdDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
            return _mapper.Map<GetProductByIdDto?>(product ?? new());
        }
    }
}
