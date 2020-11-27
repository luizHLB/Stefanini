using Stefanini.Application.Apps.Base;
using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Application;
using Stefanini.Domain.Interfaces.Service;
using System.Threading.Tasks;

namespace Stefanini.Application.Apps
{
    public class UserApp : BaseApp<User>, IUserApplication
    {
        private readonly IUserService service;
        public UserApp(IUserService service) : base(service)
        {
            this.service = service;
        }

        public async Task<User> Login(LoginModel login)
        {
            return await service.Login(login);
        }
    }
}
