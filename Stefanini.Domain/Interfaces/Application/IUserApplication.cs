using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Application.Base;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Application
{
    public interface IUserApplication : IBaseApplication<User>
    {
        Task<User> Login(LoginModel login);
    }
}
