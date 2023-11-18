using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;

        public ProfileController(UserManager<ApiUser> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("/profile/{id}")]
        public async Task<IActionResult> GetUserProfile(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user is null)
                return NotFound();

            return Ok();
        }
    }
}
