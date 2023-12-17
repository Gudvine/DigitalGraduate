using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.CertificateApplication;
using DigitalGraduate.Data.DAL.EntranceTest;
using DigitalGraduate.Data.Models.DTO.EntranceTest;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificateApplicationController : ControllerBase
    {
        private readonly IRepository<CertificateApplication> _repository;

        public CertificateApplicationController(IRepository<CertificateApplication> repostiory)
            => _repository = repostiory;

        [HttpGet("/orderCertificateRecords")]
        public async Task<IActionResult> GetAllDissertations()
            => Ok(await _repository.GetAll());

        [HttpPost("/orderCertificate")]
        public async Task<IActionResult> CreateEntranceTest(CertificateApplication certificateApplication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _repository.Create(certificateApplication);

            return Ok(certificateApplication);
        }
    }
}
