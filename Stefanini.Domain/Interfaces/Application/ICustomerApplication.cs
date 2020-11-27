using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Application.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Application
{
    public interface ICustomerApplication : IBaseApplication<Customer>
    {
        Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter);
    }
}
