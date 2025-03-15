

namespace Shop.Application.DTOs.CategoryDto
{
    public class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }
}
