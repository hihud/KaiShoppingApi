using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kai.Api.Models;
using Kai.Core.User;
using Kai.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kai.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserModel user)
        {
            IActionResult response = Unauthorized();
            var userDto = _userService.Login(user);
            if (userDto == null)
                return response;
            var token = _userService.GenerateToken(userDto);
            if (token != null)
            {
                return Ok(new LoginUserModel()
                {
                    Username = userDto.Username,
                    Token = token
                });
            }
            return BadRequest();
        }

        [Authorize]
        [HttpGet]
        [Route("getInfor")]
        public IActionResult GetInfor()
        {
            var currentUser = HttpContext.User;
            var user = new UserModel { };
            user.Type = currentUser.Claims.FirstOrDefault(c => c.Type == "type").Value;
            user.Username = currentUser.Claims.FirstOrDefault(c => c.Type == "username").Value;
            var test = HttpContext.User;
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody]UserModel user)
        {
            if (user == null)
                return BadRequest("Unable to register");
            _userService.Register(user);
            return Ok();
        }
    }
}