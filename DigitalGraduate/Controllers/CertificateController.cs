using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.Certificates;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class CertificateController : ControllerBase
    {
        readonly UserManager<ApiUser> _userManager;
        readonly ApplicationDbContext _context;

        public CertificateController(UserManager<ApiUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize(Roles = "Admin,Student,Employee")]
        [HttpPost("/application-certificate")]
        public async Task<IActionResult> CreateCertificateApplication(ApplicationCertificateModel certificateModel)
        {
            var currentUser = HttpContext.User.Identity as ClaimsIdentity;
            
            if (currentUser is null)
            {
                return Unauthorized();
            }

            //var student = _userManager.FindByEmailAsync()

            CertificateApplication application = new()
            {
                Count = int.Parse(certificateModel.Count),
                ProvideTo = certificateModel.Type,
                WithOfficialSeal = certificateModel.WithOfficialSeal,
            };

            return Ok();
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("/certificates")]
        public async Task<ActionResult<List<CertificateApplication>>> GetAllCertificateApplications()
        {
            return await _context.CertificateApplications.Include(x => x.Student).ToListAsync();
        }
    }
}
