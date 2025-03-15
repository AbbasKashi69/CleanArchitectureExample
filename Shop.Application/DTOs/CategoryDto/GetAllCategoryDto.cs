

namespace Shop.Application.DTOs.CategoryDto
{
    public class GetAllCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
