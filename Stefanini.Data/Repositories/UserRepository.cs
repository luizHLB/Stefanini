using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Context;
using Stefanini.Data.Repositories.Base;
using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace Stefanini.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<User> GetUser(LoginModel login)
        {
            return await DbSet.Include(i => i.UserRole).FirstOrDefaultAsync(f => f.Email.Equals(login.Email) && f.Password.Equals(login.Password));
        }
    }
}
