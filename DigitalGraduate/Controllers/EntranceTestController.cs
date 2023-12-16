using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.EntranceTest;
using DigitalGraduate.Data.DAL.Student;
using DigitalGraduate.Data.Models.DTO.EntranceTest;
using DigitalGraduate.Data.Models.DTO.Profile.Student;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntranceTestController : ControllerBase
    {
        private readonly IRepository<EntranceTest> _repostiory; 

        public EntranceTestController(IRepository<EntranceTest> repostiory)
            => _repostiory = repostiory;

        [HttpGet("/entranceTests/{id}")]
        public async Task<IActionResult> GetEntranceTests(string id)
        {
            List<EntranceTestDTO> entranceTestsDtos = new();

            var entranceTests = (await _repostiory.GetAll()).Where(x => x.UserId == id);

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
            => Ok(await _repostiory.GetAll());

        [HttpPost("/entranceTests/create")]
        public async Task<IActionResult> CreateEntranceTest(EntranceTestDTO entranceTest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EntranceTest newEntranceTest = new()
            {
                Title = entranceTest.Title,
                Grade = entranceTest.Grade,
                UserId = entranceTest.UserId
            };

            var result = await _repostiory.Create(newEntranceTest);

            entranceTest.Id = result.Id;

            return Ok(entranceTest);
        }

        [HttpPost("/editEntranceTest/{id}")]
        public async Task<IActionResult> EditEntranceTest(EntranceTestDTO entranceTest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EntranceTest newEntranceTest = new()
            {
                Title = entranceTest.Title,
                Grade = entranceTest.Grade,
                UserId = entranceTest.UserId
            };

            await _repostiory.Update(newEntranceTest);

            return Ok(entranceTest);
        }

        [HttpPost("/deleteEntranceTest/{id}")]
        public async Task<IActionResult> DeleteEntranceTest(int id)
        {
            await _repostiory.Delete(id);

            var deletedEntranceTest = _repostiory.GetById(id);

            if (deletedEntranceTest is null)
                return NotFound();

            return Ok();
        }
    }
}
