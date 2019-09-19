using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;



namespace SmashApi.Controllers
{
    [Route("api/auth")]
    public class TokenController : Controller
    {
        private IConfiguration _config;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public TokenController(IConfiguration config, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _config = config;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var result = await _signInManager.PasswordSignInAsync(login.Username, login.Password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(login.Username);
                var roles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>();
                foreach(String role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));                    
                }
                var tokenString = BuildToken(claims.ToArray());
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private string BuildToken(Claim[] claim)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],                
                claim,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }


    }
    
}