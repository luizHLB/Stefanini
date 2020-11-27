using Microsoft.AspNetCore.Mvc;
using Stefanini.ApiRest.Controllers.Base;
using Stefanini.ApiRest.Security;
using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Interfaces.Application;
using System.Threading.Tasks;

namespace Stefanini.ApiRest.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class UserController : StefaniniControllerBase
    {
        private readonly IUserApplication app;
        public UserController(IUserApplication app)
        {
            this.app = app;
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginModel login)
        {
            var user = await app.Login(login);
            var response = UserManager.RegisterUser(user);

            return Ok(GetResponse(response));
        }
    }
}
