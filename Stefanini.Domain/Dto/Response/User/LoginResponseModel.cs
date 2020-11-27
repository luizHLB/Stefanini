using System;

namespace Stefanini.Domain.Dto.Response.User
{
    public class LoginResponseModel
    {
        public string Login { get; set; }
        public Guid Token { get; set; }
    }
}
