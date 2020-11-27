using Stefanini.Domain.Entities.Base;
using Stefanini.Domain.Interfaces.Repository.Base;
using Stefanini.Domain.Interfaces.Service.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stefanini.Business.Services.Base
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual async Task Delete(int id)
        {
            await repository.Delete(id);
        }

        public virtual async Task<T> Find(int id)
        {
            return await repository.Find(id);
        }

        public virtual async Task<Dto> Find<Dto>(int id)
        {
            return await repository.Find<Dto>(id);
        }

        public virtual async Task<IQueryable<Dto>> List<Dto>(Expression<Func<T, bool>> predicate)
        {
            return await repository.List<Dto>(predicate);
        }

        public virtual async Task<T> Save(T entity)
        {
            await repository.Save(entity);
            return await Find(entity.Id);
        }

        public virtual async Task<T> Update(T entity)
        {
            await repository.Update(entity);
            return await Find(entity.Id);
        }
    }
}
