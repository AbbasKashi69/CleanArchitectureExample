
using Microsoft.EntityFrameworkCore;
using Shop.Shared;

namespace Shop.Application.Extensions
{
    public static class LinqExtensions
    {
        public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize, CancellationToken cancellationToken) where T : class
        {
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;

            int count = await source.CountAsync();

            List<T> items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            return new PaginatedResult<T>
            {
                Items = items,
                TotalCount = count,
                Page = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
