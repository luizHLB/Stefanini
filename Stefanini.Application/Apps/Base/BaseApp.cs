using Stefanini.Domain.Entities.Base;
using Stefanini.Domain.Interfaces.Application.Base;
using Stefanini.Domain.Interfaces.Service.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stefanini.Application.Apps.Base
{
    public class BaseApp<T> : IBaseApplication<T> where T : BaseEntity
    {
        private readonly IBaseService<T> service;
        public BaseApp(IBaseService<T> service)
        {
            this.service = service;
        }

        public virtual async Task Delete(int id)
        {
            await service.Delete(id);
        }

        public virtual async Task<T> Find(int id)
        {
            return await service.Find(id);
        }

        public virtual async Task<Dto> Find<Dto>(int id)
        {
            return await service.Find<Dto>(id);
        }

        public virtual async Task<IQueryable<Dto>> List<Dto>(Expression<Func<T, bool>> predicate)
        {
            return await service.List<Dto>(predicate);
        }

        public virtual async Task<T> Save(T entity)
        {
            return await service.Save(entity);
        }

        public virtual async Task<T> Update(T entity)
        {
            return await service.Update(entity);
        }
    }
}
