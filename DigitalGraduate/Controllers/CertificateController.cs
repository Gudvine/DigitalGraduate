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

            var userNameClaim = currentUser.Claims.Where(x => x.Type == ClaimsIdentity.DefaultNameClaimType).FirstOrDefault();

            if (userNameClaim is not null)
            {
                var userAccount = await _userManager.FindByEmailAsync(userNameClaim.Value);

                if (userAccount is null)
                {
                    return NotFound("Пользователь с таким Email не найден");
                }

                var student = await _context.GraduateStudents
                .Include(x => x.Department)
                .Include(x => x.ScientificSpeciality)
                .Include(x => x.ScientificSpeciality)
                .Where(x => x.ApiUserId == userAccount.Id)
                .FirstOrDefaultAsync();

                if (student is null)
                {
                    return NotFound("Студент не найден");
                }

                CertificateApplication application = new()
                {
                    Count = int.Parse(certificateModel.Count),
                    ProvideTo = certificateModel.Type,
                    WithOfficialSeal = certificateModel.WithOfficialSeal,
                };

                var newAppliction = await _context.AddAsync(application);
                newAppliction.Entity.Student = student;
                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize(Roles = "Admin,Employee")]
        [HttpGet("/certificateApplications/getAll")]
        public async Task<ActionResult<List<CertificateApplication>>> GetAllCertificateApplications()
        {
            return await _context.CertificateApplications.Include(x => x.Student).ToListAsync();
        }
    }
}
