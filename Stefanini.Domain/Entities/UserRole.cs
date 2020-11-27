using Stefanini.Domain.Entities.Base;

namespace Stefanini.Domain.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
    }

}
