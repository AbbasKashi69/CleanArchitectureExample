

using Mapster;
using MapsterMapper;
using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;
using System.Numerics;

namespace Shop.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<ResultObject>, IMapFrom<Category>
    {
        public int Id { get; set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ResultObject> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            Category? category = await _unitOfWork.Repository<Category>()
                .GetByIdAsync(request.Id);
            if (category is null)
            {
                return new ResultObject
                {
                    Success = false,
                    Message = "دسته ای یافت نشد."
                };
            }

            await _unitOfWork.Repository<Category>().DeleteAsync(category);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = category.Id,
                Message = "دسته با موفقیت حذف شد.",
                Success = true
            };
        }
    }
}
