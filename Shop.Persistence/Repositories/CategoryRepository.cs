

using Shop.Application.Interfaces.Repositories;
using Shop.Domain.Entities;

namespace Shop.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryRepository(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }
    }
}
