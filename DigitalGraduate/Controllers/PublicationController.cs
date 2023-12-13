using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.File;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.Models.DTO.Publication;
using DigitalGraduate.Data.Models.Publication;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublicationController : ControllerBase
    {
        private IRepository<Publication> _publicationRepository;
        private IRepository<FileInstance> _fileRepository;

        public PublicationController(IRepository<Publication> publicationRepository, IRepository<FileInstance> fileRepository)
        {
            _publicationRepository = publicationRepository;
            _fileRepository = fileRepository;
        }

        [HttpGet("/publications/{id}")]
        public async Task<IEnumerable<Publication>> GetPublicationsForUser(string id)
            => (await _publicationRepository.GetAll()).Where(x => x.UserId == id);

        [HttpPost("/addPublication")]
        public async Task<IActionResult> CreatePublication(AddPublicationDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            FileInstance pubFile = new()
            {
                Content = model.File!.Content,
                Name = model.File.Name,
                Size = model.File.Size
            };

            var fileId = (await _fileRepository.Create(pubFile)).Id;

            Publication newPublication = new()
            {
                Title = model.Title,
                PublishYear = int.Parse(model.Year),
                Edition = model.Edition,
                Adviser = model.Consultant,
                PublicationType = model.PublicationType,
                UserId = model.UserId,
                FileId = fileId,
            };

            await _publicationRepository.Create(newPublication);

            return Ok();
        }

        [HttpPost("/deletePublication/{id}")]
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
