

namespace Shop.Domain.Common.Interfaces
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
