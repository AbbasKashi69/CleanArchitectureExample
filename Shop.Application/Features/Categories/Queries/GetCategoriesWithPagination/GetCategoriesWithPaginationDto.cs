namespace Shop.Application.Features.Categories.Queries.GetCategoriesWithPagination
{
    public class GetCategoriesWithPaginationDto
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool HasChild => ChildrenCount > 0;
        public int ChildrenCount { get; set; }
    }
}
