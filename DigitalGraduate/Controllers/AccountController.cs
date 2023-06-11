using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
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

            await _signInManager.SignInAsync(newUser, isPersistent: true);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }

            var actionResult = await _signInManager.PasswordSignInAsync(loginModel.UserLogin, loginModel.Password, false, false);

            if (!actionResult.Succeeded)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
