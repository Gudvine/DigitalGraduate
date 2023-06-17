using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountController : ControllerBase
    {
        private string SecretToken = "";
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(5);

        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ApplicationDbContext _appContext;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ApplicationDbContext appContext, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
            _configuration = configuration;
            SecretToken = _configuration["JwtSettings:Key"]!;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new ApiUser
            {
                UserName = model.Login,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("/auth/login")]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var actionResult = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, false, false);

            if (!actionResult.Succeeded)
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByNameAsync(loginModel.Email);

            if (user is not null)
            {
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email!),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    authClaims, 
                    "token", 
                    ClaimsIdentity.DefaultNameClaimType, 
                    ClaimsIdentity.DefaultRoleClaimType);

                var now = DateTime.UtcNow;

                var jwtToken = new JwtSecurityToken(
                notBefore: now,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretToken)), SecurityAlgorithms.HmacSha256));
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                var response = new
                {
                    token = encodedJwt,
                    username = claimsIdentity.Name
                };

                return Ok(response);
            }

            return BadRequest();
        }

        //[HttpGet("/auth/me")]
        //public async JwtSecurityToken AuthMe()
        //{
        //    var authSigningKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretToken)), SecurityAlgorithms.HmacSha256);

        //    var jwt = new JwtSecurityToken(
        //    notBefore: now,
        //    claims: claimsIdentity.Claims,
        //    expires: now.Add(TimeSpan.FromMinutes(30)),
        //            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));
        //    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        //    var response = new
        //    {
        //        access_token = encodedJwt,
        //        username = claimsIdentity.Name
        //    };

        //    return Ok(response);
        //}
    }
}
