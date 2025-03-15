
using MapsterMapper;
using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;

namespace Shop.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<ResultObject>
    {
        public DeleteProductCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public async Task<ResultObject> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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

            await _unitOfWork.Repository<Product>().DeleteAsync(product);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = product.Id,
                Message = "محصول با موفقیت حذف شد.",
                Success = true
            };
        }
    }
}
