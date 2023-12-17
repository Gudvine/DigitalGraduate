using DigitalGraduate.Data.DAL.EntranceTest;
using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.Models.DTO.EntranceTest;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntranceTestController : ControllerBase
    {
        private readonly IRepository<EntranceTest> _repository;

        public EntranceTestController(IRepository<EntranceTest> repostiory)
            => _repository = repostiory;

        [HttpGet("/entranceTests/{id}")]
        public async Task<IActionResult> GetEntranceTests(string id)
        {
            List<EntranceTestDTO> entranceTestsDtos = new();

            var entranceTests = (await _repository.GetAll()).Where(x => x.UserId == id);

            foreach (var entranceTest in entranceTests)
            {
                EntranceTestDTO dto = new()
                {
                    Id = entranceTest.Id,
                    Title = entranceTest.Title,
                    Grade = entranceTest.Grade,
                    UserId = entranceTest.UserId
                };

                entranceTestsDtos.Add(dto);
            }

            return Ok(entranceTestsDtos);
        }

        [HttpGet("/entanceTests/all")]
        public async Task<IActionResult> GetAllEntranceTests()
            => Ok(await _repository.GetAll());

        [HttpPost("/entranceTests/create")]
        public async Task<IActionResult> CreateEntranceTest(EntranceTestDTO entranceTest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EntranceTest newEntranceTest = new()
            {
                Id = entranceTest.Id,
                Title = entranceTest.Title,
                Grade = entranceTest.Grade,
                UserId = entranceTest.UserId
            };

            var result = await _repository.Create(newEntranceTest);

            entranceTest.Id = result.Id;

            return Ok(entranceTest);
        }

        [HttpPost("/editEntranceTest")]
        public async Task<IActionResult> EditEntranceTest(EntranceTestDTO entranceTest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EntranceTest newEntranceTest = new()
            {
                Id = entranceTest.Id,
                Title = entranceTest.Title,
                Grade = entranceTest.Grade,
                UserId = entranceTest.UserId
            };

            await _repository.Update(newEntranceTest);

            return Ok(entranceTest);
        }

        [HttpPost("/deleteEntranceTest/{id}")]
        public async Task<IActionResult> DeleteEntranceTest(int id)
        {
            await _repository.Delete(id);

            var deletedEntranceTest = _repository.GetById(id);

            if (deletedEntranceTest is null)
                return NotFound();

            return Ok();
        }
    }
}
