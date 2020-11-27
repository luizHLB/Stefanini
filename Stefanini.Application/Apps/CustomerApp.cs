using Microsoft.AspNetCore.Http;
using Stefanini.Application.Apps.Base;
using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Application;
using Stefanini.Domain.Interfaces.Service;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanini.Application.Apps
{
    public class CustomerApp : BaseApp<Customer>, ICustomerApplication
    {
        private readonly ICustomerService service;
        public CustomerApp(ICustomerService service) : base(service)
        {
            this.service = service;
        }

        public async Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter)
        {
            return await service.Filter(filter);
        }
    }
}
