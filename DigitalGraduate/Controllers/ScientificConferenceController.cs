using DigitalGraduate.Data.DAL;
using Microsoft.AspNetCore.Mvc;
using DigitalGraduate.Data.DAL.ScientificConference;
using DigitalGraduate.Data.Models.DTO.ScientificConference;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScientificConferenceController : ControllerBase
    {
        private readonly IRepository<ScientificConference> _repostiory;

        public ScientificConferenceController(IRepository<ScientificConference> repostiory)
            => _repostiory = repostiory;

        [HttpGet("/conferences/{id}")]
        public async Task<IActionResult> GetConferences(string id)
        {
            List<ScientificConferenceDTO> entranceTestsDtos = new();

            var scientificConferences = (await _repostiory.GetAll()).Where(x => x.UserId == id);

            foreach (var scientificConference in scientificConferences)
            {
                ScientificConferenceDTO dto = new()
                {
                    Id = scientificConference.Id,
                    Title = scientificConference.Title,
                    Year = scientificConference.Year,
                    IsWin = scientificConference.IsWinner,
                    Level = scientificConference.Scale,
                    ParticipationOption = scientificConference.Participation,
                    UserId = scientificConference.UserId
                };

                entranceTestsDtos.Add(dto);
            }

            return Ok(entranceTestsDtos);
        }

        [HttpGet("/conferences/all")]
        public async Task<IActionResult> GetAllConferences()
            => Ok(await _repostiory.GetAll());

        [HttpPost("/conferences/create")]
        public async Task<IActionResult> CreateConference(ScientificConferenceDTO conference)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ScientificConference newScientificConference = new()
            {
                Title = conference.Title,
                Year = conference.Year,
                Scale = conference.Level,
                Participation = conference.ParticipationOption, 
                IsWinner = conference.IsWin,
                UserId = conference.UserId
            };

            var result = await _repostiory.Create(newScientificConference);

            conference.Id = result.Id;

            return Ok(conference);
        }

        [HttpPost("/editConference/{id}")]
        public async Task<IActionResult> EditConference(ScientificConferenceDTO conference)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ScientificConference newScientificConference = new()
            {
                Id = conference.Id,
                Title = conference.Title,
                Year = conference.Year,
                Scale = conference.Level,
                Participation = conference.ParticipationOption,
                IsWinner = conference.IsWin,
                UserId = conference.UserId
            };

            await _repostiory.Update(newScientificConference);

            return Ok(conference);
        }

        [HttpPost("/deleteConferences/{id}")]
        public async Task<IActionResult> ConferenceTest(int id)
        {
            await _repostiory.Delete(id);

            var deletedScientificConference = _repostiory.GetById(id);

            if (deletedScientificConference is null)
                return NotFound();

            return Ok();
        }
    }
}
