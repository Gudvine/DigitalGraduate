using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ApplicationDbContext _appContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        private string TokenKey = "";

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ApplicationDbContext appContext, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
            _configuration = configuration;
            _roleManager = roleManager;

            TokenKey = _configuration["JwtSettings:Key"]!;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleExists = await _roleManager.RoleExistsAsync(model.UserRole);

            if (!roleExists)
            {
                return BadRequest(new { Error = "Такая роль не существует" });
            }

            var newUser = new ApiUser
            {
                UserName = model.Login,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var roleResult = await _userManager.AddToRoleAsync(newUser, model.UserRole);

            if (!roleResult.Succeeded)
            {
                return BadRequest(new { Error = "Что-то пошло не так!" });
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
                issuer: _configuration["JwtSettings:Issuer"]!,
                audience: _configuration["JwtSettings:Audience"]!,
                claims: claimsIdentity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(20)),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)), SecurityAlgorithms.HmacSha256));
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

        [HttpGet("/auth/me")]
        public async Task<IActionResult> AuthMe()
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("someShit", "shiit"),
            };

            var authSigningKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)), SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                claims,
                "token",
                ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
            notBefore: now,
            claims: claimsIdentity.Claims,
            issuer: _configuration["jwtsettings:issuer"]!,
            audience: _configuration["jwtsettings:audience"]!,
            expires: now.Add(TimeSpan.FromMinutes(20)),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)), SecurityAlgorithms.HmacSha256));
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
