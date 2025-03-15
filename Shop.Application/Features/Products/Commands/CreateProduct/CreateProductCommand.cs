

using MapsterMapper;
using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;

namespace Shop.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ResultObject>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string? Picture { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultObject> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = product.Id,
                Message = "محصول جدید با موفقیت اضافه شد.",
                Success = true
            };
        }
    }
}
