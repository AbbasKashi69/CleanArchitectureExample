

using Shop.Domain.Common.Interfaces;

namespace Shop.Domain.Common
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
