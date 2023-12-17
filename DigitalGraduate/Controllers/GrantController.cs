using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Grant;
using DigitalGraduate.Data.Models.DTO.Grant;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("/grants")]
    public class GrantController : ControllerBase
    {
        private IRepository<Grant> _repository;

        public GrantController(IRepository<Grant> repository)
        {
            _repository = repository;
        }

        [HttpGet("/grants/{id}")]
        public async Task<IEnumerable<Grant>> GetGrants(string id)
            => await _repository.GetAll();

        [HttpPost("/addGrant")]
        public async Task<IActionResult> CreateGrant(GrantDTO grant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newGrant = new Grant()
            {
                Title = grant.Title,
                GrantParticipation = Data.Models.Enums.GrantParticipation.Participant,
            };

            var result = await _repository.Create(newGrant);

            if (result is null)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("/deleteGrant")]
        public async Task<IActionResult> DeleteGrant(int id)
        {
            await _repository.Delete(id);

            return Ok();
        }

        [HttpPost("/editGrant")]
        public async Task<GrantDTO?> EditGrant(GrantDTO grant)
        {
            var grantToEdit = new Grant()
            {
                Title = grant.Title,
                GrantParticipation = Data.Models.Enums.GrantParticipation.Participant,
                Id = grant.Id,
            };

            var result = await _repository.Update(grantToEdit);

            if (result is null)
                return null;

            var grantDto = new GrantDTO()
            {
                Id = result.Id,
                Participation = result.GrantParticipation.ToString(),
                Title = grant.Title
            };

            return grantDto;
        }
    }
}
