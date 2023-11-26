using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.Models.Publication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationController : ControllerBase
    {
        private IRepository<Publication> _publicationRepository;

        public PublicationController(IRepository<Publication> publicationRepository)
        {
            _publicationRepository = publicationRepository;
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("all")]
        public async Task<IEnumerable<Publication>> GetAllPublicationsForAdmin()
        {
            return await _publicationRepository.GetAll();
        }

        [HttpPost("/addPublication")]
        public async Task<IActionResult> CreatePublication(PublicationModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Publication newPublication = new()
            {
                Name = model.Title,
                PublishYear = model.Year,
                Edition = model.Edition,
            };

            await _publicationRepository.Create(newPublication);

            return Ok(newPublication.Id);
        }

        [HttpPost("/delete/{id}")]
        public async Task<IActionResult> DeletePublication(int id)
        {
            var publication = await _publicationRepository.GetById(id);

            if (publication is null)
                return NotFound($"Публикация с id {id} не найдена");

            await _publicationRepository.Delete(id);

            return Ok();
        }

        [HttpPost("/updatePublication")]
        public async Task<Publication> UpdatePublication(PublicationModel model)
        {
            return new();
        }
    }
}
