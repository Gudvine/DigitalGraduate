using DigitalGraduate.Data.Models.Certificates;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class CertificateController : ControllerBase
    {
        [HttpPost("/application-certificate")]
        public async Task<IActionResult> CreateCertificateApllication(ApplicationCertificateModel certificateModel)
        {
            return Ok();
        }
    }
}
