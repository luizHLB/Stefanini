using Microsoft.AspNetCore.Http;
using Stefanini.Domain.Dto.Response.User;
using Stefanini.Domain.Entities;
using Stefanini.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ApiRest.Security
{
    public static class UserManager
    {
        private static IList<UserInfo> users;

        public static void Validate(HttpRequest request)
        {
            var header = request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("authorization"));

            if (!header.Value.ToList().Any())
                throw new TokenException("Authorization is missing");

            var tokenRequest = header.Value.ToArray()[0].Replace("Bearer ", string.Empty);
            var token = Guid.Empty;
            if (string.IsNullOrEmpty(tokenRequest) || !Guid.TryParse(tokenRequest, out token) || token == Guid.Empty)
                throw new TokenException("Authorization invalid");

            request.HttpContext.Items.Add("UserLogin", GetUser(token));
        }

        public static UserInfo GetUser(Guid token)
        {
            users ??= new List<UserInfo>();

            var user = users.FirstOrDefault(f => f.Token.Equals(token));
            user.LastConnection = DateTime.Now;
            return user;
        }

        public static LoginResponseModel RegisterUser(User user)
        {
            var token = Register(user.Id, user.UserRole.IsAdmin);
            return new LoginResponseModel { Login = user.Login, Token = token };
        }

        private static Guid Register(int id, bool isAdmin)
        {
            users ??= new List<UserInfo>();

            if (!users.Any(a => a.Id.Equals(id)))
            {
                users.Add(new UserInfo(id, Guid.NewGuid(), isAdmin));
            }

            var response = users.FirstOrDefault(f => f.Id.Equals(id));
            response.LastConnection = DateTime.Now;

            return response.Token;
        }
    }
}
