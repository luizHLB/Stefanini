using Stefanini.Domain.Dto.Request.Filter;
using Stefanini.Domain.Dto.Response;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Repository.Base;
using System.Linq;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Repository
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IQueryable<CustomerResponseModel>> Filter(CustomerFilter filter);
    }
}
