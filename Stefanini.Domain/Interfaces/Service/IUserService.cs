using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Service.Base;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Service
{
    public interface IUserService : IBaseService<User>
    {
        Task<User> Login(LoginModel login);
    }
}
