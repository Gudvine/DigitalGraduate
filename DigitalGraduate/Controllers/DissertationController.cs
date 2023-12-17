using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Dissertation;
using DigitalGraduate.Data.DAL.File;
using DigitalGraduate.Data.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DissertationController : ControllerBase
    {
        private readonly IRepository<Dissertation> _repository; 

        public DissertationController(IRepository<Dissertation> repostiory)
            => _repository = repostiory;

        [HttpGet("/dissertations/{id}")]
        public async Task<IActionResult> GetDissertations(string id)
        {
            List<DissertationDTO> dissertationsDtos = new();

            var dissertations = (await _repository.GetAll()).Where(x => x.UserId == id);

            foreach (var dissertation in dissertations)
            {
                DissertationDTO dto = new()
                {
                    Id = dissertation.Id,
                    DefenseDate = dissertation.DefenseDate,
                    Status = dissertation.Status,
                    File = new FileInstance() 
                    {
                        Id = dissertation.File.Id,
                        Content = dissertation.File.Content,
                        Name = dissertation.File.Name,
                        Size = dissertation.File.Size,
                    },
                    UserId = dissertation.UserId
                };

                dissertationsDtos.Add(dto);
            }

            return Ok(dissertationsDtos);
        }

        [HttpGet("/dissertations/all")]
        public async Task<IActionResult> GetAllDissertations()
            => Ok(await _repository.GetAll());

        [HttpPost("/dissertations/create")]
        public async Task<IActionResult> CreateDissertation(DissertationDTO dissertation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Dissertation newDissertation = new()
            {
                DefenseDate = dissertation.DefenseDate,
                Status = dissertation.Status,
                File = new FileInstance()
                {
                    Content = dissertation.File.Content,
                    Name = dissertation.File.Name,
                    Size = dissertation.File.Size,
                },
                UserId = dissertation.UserId
            };

            var result = await _repository.Create(newDissertation);

            dissertation.Id = result.Id;
            dissertation.File.Id = result.File.Id;

            return Ok(dissertation);
        }

        [HttpPost("/editDissertation")]
        public async Task<IActionResult> EditDissertation(DissertationDTO dissertation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Dissertation newDissertation = new()
            {
                Id = dissertation.Id,
                DefenseDate = dissertation.DefenseDate,
                Status = dissertation.Status,
                File = new FileInstance()
                {
                    Id = dissertation.File.Id,
                    Content = dissertation.File.Content,
                    Name = dissertation.File.Name,
                    Size = dissertation.File.Size,
                },
                UserId = dissertation.UserId
            };

            await _repository.Update(newDissertation);

            return Ok(dissertation);
        }

        [HttpPost("/deleteDissertation/{id}")]
        public async Task<IActionResult> DeleteDissertation(int id)
        {
            await _repository.Delete(id);

            var deletedDissertation = _repository.GetById(id);

            if (deletedDissertation is null)
                return NotFound();

            return Ok();
        }
    }
}
