using Stefanini.Domain.Entities.Base;

namespace Stefanini.Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
