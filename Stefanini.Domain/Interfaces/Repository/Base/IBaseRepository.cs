using Stefanini.Domain.Entities.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stefanini.Domain.Interfaces.Repository.Base
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> Find(int id);
        Task<Dto> Find<Dto>(int id);
        Task<IQueryable<Dto>> List<Dto>(Expression<Func<T, bool>> predicate);
    }
}
