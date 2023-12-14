using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.Student;
using DigitalGraduate.Data.Models.DTO.Profile.Student;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IRepository<Student> _studentRepository;

        public ProfileController(UserManager<ApiUser> userManager, IRepository<Student> studentRepository)
        {
            _userManager = userManager;
            _studentRepository = studentRepository;
        }

        #region StudentProfile

        [HttpGet("/student/{id}")]
        public async Task<IActionResult> GetStudentProfile(string id)
        {
            var studentProfile = (await _studentRepository.GetAll()).FirstOrDefault(x => x.UserId == id);

            if (studentProfile is null)
                return NotFound("Профиль студента с таким id пользователя не надйен");

            StudentDTO studentDTO = new()
            {
                Id = studentProfile.Id,
                Name = studentProfile.Name,
                LastName = studentProfile.LastName,
                Patronymic = studentProfile.Patronymic,
                BirthDate = studentProfile.BirthDate,
                IsBudget = studentProfile.IsBudget,
                Year = studentProfile.Year,
                UserId = id
            };

            return Ok(studentDTO);
        }

        [HttpPost("/student/create")]
        public async Task<IActionResult> CreateStudentProfile(CreateStudentDTO student)
        {


            return Ok();
        }

        #endregion
    }
}
