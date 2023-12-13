using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.DAL.ScientificCompetition;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScientificCompetitionController : ControllerBase
    {
        private IRepository<ScientificCompetition> _repository;

        public ScientificCompetitionController(IRepository<ScientificCompetition> repository)
        {
            _repository = repository;
        }

        [HttpGet("/competitions/{id}")]
        public async Task<IEnumerable<ScientificCompetition>> GetScientificCompetitionsForUser(string id)
            => (await _repository.GetAll()).Where(x => x.UserId == id);

        public async Task<IActionResult> CreateScientificCompetition(ScientificCompetition scientificComp)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _repository.Create(scientificComp);

            return Ok();
        }
    }
}
