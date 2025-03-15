

using Mapster;
using MapsterMapper;
using MediatR;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;
using Shop.Shared;
using System.Numerics;

namespace Shop.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<ResultObject>, IMapFrom<Category>
    {
        public CreateCategoryCommand(int? parentId, string name)
        {
            ParentId = parentId;
            Name = name;
        }

        public int? ParentId { get; set; }
        public string Name { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, ResultObject>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<ResultObject> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);

            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.Save(cancellationToken);
            return new ResultObject
            {
                Id = category.Id,
                Message = "دسته جدید با موفقیت اضافه شد.",
                Success = true
            };
        }
    }
}
