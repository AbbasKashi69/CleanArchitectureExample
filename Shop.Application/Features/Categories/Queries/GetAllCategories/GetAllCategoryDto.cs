namespace Shop.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
