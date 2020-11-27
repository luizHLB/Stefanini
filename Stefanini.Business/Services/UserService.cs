using Stefanini.Business.Services.Base;
using Stefanini.Domain.Dto.Request.Login;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Exceptions;
using Stefanini.Domain.Interfaces.Repository;
using Stefanini.Domain.Interfaces.Service;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            login.Password = MD5Encrypt(login.Password);

            var user = await repository.GetUser(login);
            if (user is null)
                throw new UserException("The email and/or password entered is invalid. Please try again.");

            return user;
        }

        private string MD5Encrypt(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            return string.Join(string.Empty, md5.Hash.Select(s => s.ToString("x2")));
        }
    }
}
