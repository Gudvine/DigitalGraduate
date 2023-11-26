using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.Models.Publication;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPublications()
        {
            return Ok(_publicationRepository.GetAll());
        }

        [HttpPost("/addPublication")]
        public IActionResult CreatePublication(PublicationModel model)
        {
            //byte[] fileArray = (byte[])model.File; 

            return Ok();
        }
    }
}
