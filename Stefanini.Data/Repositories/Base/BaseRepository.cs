using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;
using Stefanini.Data.Extensions;
using Stefanini.Domain.Entities.Base;
using Stefanini.Domain.Interfaces.Repository.Base;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stefanini.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext Context;
        protected readonly DbSet<T> DbSet;

        private readonly IMapper mapper;

        public BaseRepository(DataContext context, IMapper mapper)
        {
            Context = context;
            DbSet = context.Set<T>();
            this.mapper = mapper;
        }

        public virtual async Task Save(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public virtual async Task Update(T entity)
        {
            await Task.FromResult(DbSet.Update(entity));
        }

        public virtual async Task Delete(int id)
        {
            var entity = DbSet.Find(id);
            await Task.FromResult(DbSet.Remove(entity));
        }

        public virtual async Task<T> Find(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<Dto> Find<Dto>(int id)
        {
            return await Task.FromResult(await DbSet.FindAsync(id).MapTo<Dto>(mapper));
        }

        public virtual async Task<IQueryable<Dto>> List<Dto>(Expression<Func<T, bool>> predicate)
        {
            if (ReferenceEquals(typeof(Dto), typeof(T)))
                return await Task.FromResult(DbSet.Where(predicate) as IQueryable<Dto>);

            return await Task.FromResult(mapper.ProjectTo<Dto>(DbSet.Where(predicate)));
        }
    }
}
