using Kai.Core.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Service.UserService
{
    public interface IUserService
    {
        string Login(UserModel user);
        UserModel Register(UserModel user);
        UserModel GetUser(int Id);
    }
}
