using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Identity;
using DigitalGraduate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("auth/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AuthenticationService _authService;

        public AccountController(
            UserManager<ApiUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AuthenticationService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost("addDefaultRoles")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddDefaultRoles()
        {
            string[] roles = new string[]
            {
                "admin",
                "student",
                "mentor",
                "employee"
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
        public async Task<IActionResult> RegisterUser(RegisterDTO model)
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
        [HttpPost("/login")]
        public async Task<IActionResult> LoginUser(LoginDTO loginModel)
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

                var userRole = (await _userManager.GetRolesAsync(user)).ToList().FirstOrDefault();

                UserDTO userModel = new()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    UserRole = userRole is null ? "student" : userRole,
                    Token = encodedJwt
                };

                return Ok(userModel);
            }

            return Unauthorized("Логин или пароль введен неверно");
        }
    }
}
