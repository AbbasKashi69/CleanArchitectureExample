
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductRepository(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public Task<List<Product>> GetByCategoryId(int categoryId)
        {
            return _repository.Entities.Where(w=> w.CategoryId == categoryId).ToListAsync();
        }
    }
}
