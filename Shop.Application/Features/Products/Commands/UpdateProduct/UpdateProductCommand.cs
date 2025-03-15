
using MapsterMapper;
using MediatR;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;

namespace Shop.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ResultObject>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string? Picture { get; set; }
    }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultObject> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
            if (product is null)
            {
                return new ResultObject
                {
                    Success = false,
                    Message = "محصولی یافت نشد."
                };
            }

            _mapper.Map(request, product);

            await _unitOfWork.Repository<Product>().UpdateAsync(product);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = product.Id,
                Message = "محصول با موفقیت اضافه شد.",
                Success = true
            };
        }
    }
}
