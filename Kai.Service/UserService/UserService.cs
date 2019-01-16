using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Kai.Core.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kai.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _config;

        public UserService(IConfiguration config)
        {
            _config = config;
        }
        public string Login(UserModel user)
        {
           if(user == null)
            {
                return null;
            }
            var userModel = AuthenticateUser(user);

            if (userModel != null)
            {
                return GenerateJSONWebToken(userModel);
            }
            else return null;
        }

        public UserModel Register(UserModel user)
        {
            throw new NotImplementedException();
        }

        public UserModel GetUser(int Id)
        {
            return new UserModel { Username = "hihud", Password = "123" };
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials  
            //Demo Purpose, I have Passed HardCoded User Information  
            if (login.Username == "hihud")
            {
                user = new UserModel { Username = "Jignesh Trivedi", Email = "test.btest@gmail.com" };
            }
            return user;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
