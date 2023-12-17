using DigitalGraduate.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using DigitalGraduate.Data.DAL.Certification;
using DigitalGraduate.Data.Models.DTO.Certification;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CertificationController : ControllerBase
    {
        private readonly IRepository<Certification> _repostiory;

        public CertificationController(IRepository<Certification> repostiory)
            => _repostiory = repostiory;

        [HttpGet("/certifications/{id}")]
        public async Task<IActionResult> GetCertifications(string id)
        {
            List<CertificationDTO> certificationsDtos = new();

            var certifications = (await _repostiory.GetAll()).Where(x => x.UserId == id);

            foreach (var certification in certifications)
            {
                CertificationDTO dto = new()
                {
                    Id = certification.Id,
                    Semester = certification.Semester,
                    Result = certification.Result,
                    UserId = certification.UserId
                };

                certificationsDtos.Add(dto);
            }

            return Ok(certificationsDtos);
        }

        [HttpGet("/certifications/all")]
        public async Task<IActionResult> GetAllCertifications()
            => Ok(await _repostiory.GetAll());

        [HttpPost("/certifications/create")]
        public async Task<IActionResult> CreateEntranceTest(CertificationDTO certification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Certification newCertification = new()
            {
                Semester = certification.Semester,
                Result = certification.Result,
                UserId = certification.UserId
            };

            var result = await _repostiory.Create(newCertification);

            certification.Id = result.Id;

            return Ok(certification);
        }

        [HttpPost("/editСertification/{id}")]
        public async Task<IActionResult> EditEntranceTest(CertificationDTO certification)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Certification newCertification = new()
            {
                Id = certification.Id,
                Semester = certification.Semester,
                Result = certification.Result,
                UserId = certification.UserId
            };

            await _repostiory.Update(newCertification);

            return Ok(certification);
        }

        [HttpPost("/deleteСertification/{id}")]
        public async Task<IActionResult> DeleteEntranceTest(int id)
        {
            await _repostiory.Delete(id);

            var deletedCertification = _repostiory.GetById(id);

            if (deletedCertification is null)
                return NotFound();

            return Ok();
        }
    }
}
