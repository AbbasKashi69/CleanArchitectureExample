namespace Shop.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }
}
