using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Features.Categories.Queries;
using Shop.Application.Features.Products.Commands.CreateProduct;
using Shop.Application.Features.Products.Commands.DeleteProduct;
using Shop.Application.Features.Products.Commands.UpdateProduct;
using Shop.Application.Features.Products.Queries.GetAllProduct;
using Shop.Application.Features.Products.Queries.GetProductById;
using Shop.Application.Features.Products.Queries.GetProductsWithPagination;
using Shop.Shared;

namespace Shop.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllProductDto>> GetAll()
            => await _mediator.Send(new GetAllProductQuery());

        [HttpGet]
        public async Task<PaginatedResult<GetProductsWithPaginationDto>> GetPagination(int page, int pageSize)
            => await _mediator.Send(new GetProductsWithPaginationQuery(page, pageSize));

        [HttpGet]
        public async Task<GetProductByIdDto?> GetById(int id)
            => await _mediator.Send(new GetProductByIdQuery(id));

        [HttpPost]
        public async Task<ResultObject> Create(CreateProductCommand command)
            => await _mediator.Send(command);

        [HttpPut]
        public async Task<ResultObject> Update(UpdateProductCommand command)
            => await _mediator.Send(command);

        [HttpDelete("{id:int}")]
        public async Task<ResultObject> Delete(int id)
            => await _mediator.Send(new DeleteProductCommand(id));
    }
}
