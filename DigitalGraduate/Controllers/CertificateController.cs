using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.Certificates;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("/application-certificate")]
        public async Task<IActionResult> CreateCertificateApplication(ApplicationCertificateModel certificateModel)
        {
            CertificateApplication application = new()
            {
                Count = int.Parse(certificateModel.Count),
                ProvideTo = certificateModel.Type,
                WithOfficialSeal = certificateModel.WithOfficialSeal,
            };

            return Ok();
        }
    }
}
