using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stefanini.ApiRest.Controllers.Base;
using Stefanini.ApiRest.Security;
using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Dto.Response.User;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Application;
using System.Threading.Tasks;

namespace Stefanini.ApiRest.Controllers.v1
{
    [Route("api/v1/[controller]")]
    public class CustomerController : StefaniniControllerBase
    {
        private readonly ICustomerApplication app;

        public CustomerController(ICustomerApplication app)
        {
            this.app = app;
        }

        [HttpGet]
        [AccessValidation]
        public async Task<ActionResult<CustomerResponseModel>> List([FromQuery]CustomerFilter filter)
        {
            return Ok(GetResponse(await app.Filter(filter)));
        }
    }
}
