using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Identity;
using DigitalGraduate.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        private readonly AuthenticationService _authService;

        public AccountController(
            UserManager<ApiUser> userManager, 
            SignInManager<ApiUser> signInManager, 
            ApplicationDbContext appContext, 
            IConfiguration configuration, 
            RoleManager<IdentityRole> roleManager,
            AuthenticationService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
            _configuration = configuration;
            _roleManager = roleManager;
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("addDefaultRoles")]
        public async Task<IActionResult> AddDefaultRoles()
        {
            string[] roles = new string[]
            {
                "Admin",
                "Student",
                "ScientificMentor",
            };

            foreach (var role in roles)
            {
                var roleExists = await _roleManager.RoleExistsAsync(role);

                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole()
                    {
                        Name = role,
                    });
                }
            }

            return Ok("Инициализация базовых ролей завершена");
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

            //if (model.UserRole == "Student")
            //{
            //    await _userManager.AddClaimAsync(newUser, new Claim(ClaimTypes.));
            //}

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

            var user = await _userManager.FindByNameAsync(loginModel.Email);

            if (user is not null)
            {
                var encodedJwt = _authService.GenerateToken(user);

                var response = new
                {
                    token = encodedJwt,
                };

                return Ok(response);
            }

            return BadRequest();
        }

        [HttpGet("/auth/me")]
        public async Task<IActionResult> AuthMe()
        {
            var authSigningKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenKey)), SecurityAlgorithms.HmacSha256);

            var currentUser = HttpContext.User.Identity as ClaimsIdentity;

            var userNameClaim = currentUser.Claims.Where(x => x.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault();

            var userAccount = await _userManager.FindByEmailAsync(userNameClaim.Value);

            var now = DateTime.UtcNow;

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                currentUser.Claims,
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
