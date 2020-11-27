using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Repository.Base;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUser(LoginModel login);
    }
}
