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
        private readonly AuthenticationService _authService;

        public AccountController(
            UserManager<ApiUser> userManager,
            SignInManager<ApiUser> signInManager,
            ApplicationDbContext appContext,
            RoleManager<IdentityRole> roleManager,
            AuthenticationService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appContext = appContext;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost("addDefaultRoles")]
        [Authorize(Roles = "Admin")]
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
        [HttpPost("/auth/register")]
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
                Email = model.Email,
                FirstName = model.FirstName,
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

            return Ok(newUser.Id);
        }

        [AllowAnonymous]
        [HttpPost("/auth/login")]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var user = await _userManager.FindByNameAsync(loginModel.UserName);

            if (user is not null)
            {
                bool passwordIsValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);

                if (!passwordIsValid) { return Unauthorized("Логин или пароль введен неверно"); }

                var encodedJwt = _authService.GenerateToken(user);

                return Ok(encodedJwt);
            }

            return Unauthorized("Логин или пароль введен неверно");
        }

        [Authorize]
        [HttpGet("/users/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok();
        }
    }
}
