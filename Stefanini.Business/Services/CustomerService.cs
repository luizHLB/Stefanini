using Microsoft.AspNetCore.Http;
using Stefanini.Business.Services.Base;
using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Dto.Response.User;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Repository;
using Stefanini.Domain.Interfaces.Service;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanini.Business.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerRepository repository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public CustomerService(ICustomerRepository repository, IHttpContextAccessor httpContextAccessor) : base(repository)
        {
            this.repository = repository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter)
        {
            httpContextAccessor.HttpContext.Items.TryGetValue("UserLogin", out var login);
            var user = (UserInfo)login;

            if (!user.IsAdmin)
                filter.SellerId = user.Id;

            return await repository.Filter(filter);
        }
    }
}
