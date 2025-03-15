namespace Shop.Application.Features.Products.Queries.GetAllProduct
{
    public class GetAllProductDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PriceString => Price.ToString("N0");
        public string? Description { get; set; }
        public string? Tags { get; set; }
        public string[]? TagsList => Tags?.Split(",");
        public string? Picture { get; set; }
    }
}
