
namespace Shop.Application.DTOs.CategoryDto
{
    public class CreateCategoryDto
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
    }
}
