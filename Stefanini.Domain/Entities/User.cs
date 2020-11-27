using Stefanini.Domain.Entities.Base;

namespace Stefanini.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
    }

}
