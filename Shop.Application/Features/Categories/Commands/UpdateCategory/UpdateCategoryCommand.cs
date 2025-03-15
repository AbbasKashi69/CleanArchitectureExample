

using Mapster;
using MapsterMapper;
using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;
using System.Numerics;

namespace Shop.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<ResultObject>, IMapFrom<Category>
    {
        public UpdateCategoryCommand(int id, int? parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ResultObject> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
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

            _mapper.Map(request, category);

            await _unitOfWork.Repository<Category>().UpdateAsync(category);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = category.Id,
                Message = "دسته با موفقیت اضافه شد.",
                Success = true
            };
        }
    }
}
