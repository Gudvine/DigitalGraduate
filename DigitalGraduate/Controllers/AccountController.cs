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
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountController : ControllerBase
    {
        private const string SecretToken = "P8SID3zfe0PG#N!k5LVhtLAGzEPG#N!SI";
        private static readonly TimeSpan TokenLifetime = TimeSpan.FromHours(5);

        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ApplicationDbContext _appContext;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ApplicationDbContext appContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
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
                return BadRequest();
            }

            var user = await _userManager.FindByNameAsync(loginModel.Email);

            var claims = new List<Claim>
            {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mysupersecret_secretkey!123")), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = claimsIdentity.Name
            };

            return Ok(response);
        }

        [HttpGet("/auth/me")]
        public async Task<IActionResult> AuthMe()
        {
            var claimsUser = HttpContext.User;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var claims = new List<Claim>
            {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, User.Identity.Name),
                };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;

            var jwt = new JwtSecurityToken(
            notBefore: now,
            claims: claimsIdentity.Claims,
            expires: now.Add(TimeSpan.FromMinutes(30)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("mysupersecret_secretkey!123")), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = claimsIdentity.Name
            };

            return Ok(response);
        }
    }
}
