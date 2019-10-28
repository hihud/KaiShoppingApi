using Kai.Core.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Service.UserService
{
    public interface IUserService
    {
        string GenerateToken(UserModel user);
        void Register(UserModel user);
        UserModel GetUser(int Id);
        UserModel Login(UserModel user);
    }
}
