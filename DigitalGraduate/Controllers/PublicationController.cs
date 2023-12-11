using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.Models.DTO.Publication;
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

        [HttpGet("/publications/{id}")]
        public async Task<IEnumerable<Publication>> GetAllPublicationsForAdmin(string id)
            => (await _publicationRepository.GetAll()).Where(x => x.UserId == id);

        [HttpPost("/addPublication")]
        public async Task<IActionResult> CreatePublication(AddPublicationDTO model)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //Publication newPublication = new()
            //{
            //    Title = model.Title,
            //    PublishYear = model.Year,
            //    Edition = model.Edition,
            //};

            //await _publicationRepository.Create(newPublication);

            return Ok();
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
            //_publicationRepository.Update();

            return new();
        }
    }
}
