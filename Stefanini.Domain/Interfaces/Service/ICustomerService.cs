using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Service.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Service
{
    public interface ICustomerService : IBaseService<Customer>
    {
        Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter);
    }
}
