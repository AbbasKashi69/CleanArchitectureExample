

using Shop.Domain.Entities;

namespace Shop.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetByCategoryId(int categoryId);
    }
}
