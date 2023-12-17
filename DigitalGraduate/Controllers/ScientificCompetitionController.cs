using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.ScientificCompetition;
using DigitalGraduate.Data.Models.DTO.ScientificCompetition;
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
        public async Task<IActionResult> GetCompetitons(string id)
        {
            List<ScientificCompetitionDTO> competitionsDtos = new();

            var competitions = (await _repository.GetAll()).Where(x => x.UserId == id);

            foreach (var competition in competitions)
            {
                ScientificCompetitionDTO dto = new()
                {
                    Id = competition.Id,
                    Result = competition.Result,
                    Title = competition.Title,
                    UserId = competition.UserId,
                    Year = competition.Year
                };

                competitionsDtos.Add(dto);
            }

            return Ok(competitionsDtos);
        }

        [HttpGet("/competitions/all")]
        public async Task<IActionResult> GetAllCompetitions()
            => Ok(await _repository.GetAll());

        [HttpPost("/competitions/create")]
        public async Task<IActionResult> CreateCompetition(ScientificCompetitionDTO competition)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ScientificCompetition newCompetition = new()
            {
                Result = competition.Result,
                Title = competition.Title,
                UserId = competition.UserId,
                Year = competition.Year
            };

            var result = await _repository.Create(newCompetition);

            competition.Id = result.Id;

            return Ok(competition);
        }

        [HttpPost("/editCompetition/{id}")]
        public async Task<IActionResult> EditCompetition(ScientificCompetitionDTO competition)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ScientificCompetition newScientificCompetition = new()
            {
                Id = competition.Id,
                Result = competition.Result,
                Title = competition.Title,
                UserId = competition.UserId,
                Year = competition.Year
            };

            await _repository.Update(newScientificCompetition);

            return Ok(competition);
        }

        [HttpPost("/deleteCompetition/{id}")]
        public async Task<IActionResult> DeleteCompetition(int id)
        {
            await _repository.Delete(id);

            var deletedCompetition = _repository.GetById(id);

            if (deletedCompetition is null)
                return NotFound();

            return Ok();
        }
    }
}
