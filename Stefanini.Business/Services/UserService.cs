using Stefanini.Business.Services.Base;
using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Exceptions;
using Stefanini.Domain.Interfaces.Repository;
using Stefanini.Domain.Interfaces.Service;
using System;
using System.Threading.Tasks;

namespace Stefanini.Business.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository repository;
        public UserService(IUserRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<User> Login(LoginModel login)
        {
            var user = await repository.GetUser(login);
            if (user is null)
                throw new UserException("The email and/or password entered is invalid. Please try again.");


            return user;
        }
    }
}
