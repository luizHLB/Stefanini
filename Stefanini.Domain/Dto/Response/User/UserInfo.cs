using System;

namespace Stefanini.Domain.Dto.Response.User
{
    public class UserInfo
    {
        public UserInfo(int id, Guid token, bool isAdmin)
        {
            Id = id;
            Token = token;
            IsAdmin = isAdmin;
            LastConnection = DateTime.Now;
        }

        public int Id { get; set; }
        public Guid Token { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime LastConnection { get; set; }
    }
}
