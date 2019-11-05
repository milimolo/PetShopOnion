using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.Entity;
using PetShop.Infrastructure.SQL.Helper;

namespace PetShop.UI.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationHelper authenticationHelper;

        public TokensController(IUserService userService, IAuthenticationHelper authService)
        {
            _userService = userService;
            authenticationHelper = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginInputModel model)
        {
            var user = _userService.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }
    }
}