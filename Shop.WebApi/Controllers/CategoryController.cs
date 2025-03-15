using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTOs.CategoryDto;
using Shop.Application.Features.Categories.Commands;
using Shop.Application.Features.Categories.Queries;
using Shop.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllCategoryDto>> GetAll()
            => await _mediator.Send(new GetAllCategoriesQuery());

        [HttpGet]
        public async Task<PaginatedResult<GetCategoriesWithPaginationDto>> GetPagination(int page, int pageSize)
            => await _mediator.Send(new GetCategoriesWithPaginationQuery(page, pageSize));

        [HttpGet]
        public async Task<GetCategoryByIdDto?> GetById(int id)
            => await _mediator.Send(new GetCategoryByIdQuery(id));

        [HttpPost]
        public async Task<ResultObject> Create(CreateCategoryCommand command)
            => await _mediator.Send(command);

        [HttpPut]
        public async Task<ResultObject> Update(UpdateCategoryCommand command)
            => await _mediator.Send(command);

        [HttpDelete("{id:int}")]
        public async Task<ResultObject> Delete(int id)
            => await _mediator.Send(new DeleteCategoryCommand(id));
    }
}
