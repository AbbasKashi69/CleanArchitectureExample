
using Shop.Domain.Common;

namespace Shop.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string? Picture { get; set; }

        public Category? Category { get; set; }
    }
}
