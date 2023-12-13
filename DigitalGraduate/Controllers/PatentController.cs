using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Patent;
using DigitalGraduate.Data.Models.DTO.Patent;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatentController : ControllerBase
    {
        private IRepository<Patent> _repository;

        public PatentController(IRepository<Patent> repository)
        {
            _repository = repository;
        }

        [HttpGet("/patents/{id}")]
        public async Task<IEnumerable<PatentDTO>> GetPatentsForUser(string id)
        {
            List<PatentDTO> patentsDtos = new();

            var patents  = (await _repository.GetAll()).Where(x => x.UserId == id).ToList();

            foreach (var patent in patents)
            {
                PatentDTO dto = new()
                {
                    Id = patent.Id.ToString(),
                    Date = patent.IssueDate.ToString(),
                    Title = patent.Title,
                };

                patentsDtos.Add(dto);
            }

            return patentsDtos;
        }

        [HttpPost("/addPatent")]
        public async Task<IActionResult> CreatePatent(PatentDTO patent)
        {
            if (ModelState.IsValid)
                return BadRequest(ModelState);

            Patent newPatent = new()
            {
                IssueDate = DateTime.Parse(patent.Date),
                Title = patent.Title,
                UserId = patent.UserId,
            };

            await _repository.Create(newPatent);

            return Ok();
        }
    }
}
