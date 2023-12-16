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

        [HttpGet("/student/all")]
        public async Task<IActionResult> GetAllSudentsProfiles()
            => Ok(await _studentRepository.GetAll());

        [HttpPost("/student/create")]
        public async Task<IActionResult> CreateStudentProfile(CreateStudentDTO student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student newStudent = new()
            {
                Name = student.Name,
                LastName = student.LastName,
                BirthDate= student.BirthDate,
                IsBudget = student.IsBudget,
                Department = student.Department,
                Direction = student.Direction,
                EducationForm = student.EducationForm,
                EducationType = student.EducationType,
                Faculty = student.Faculty,
                GroupNumber = student.GroupNumber,
                Patronymic = student.Patronymic,
                UserId = student.UserId,
                Year = student.Year,
            };

            var result = await _studentRepository.Create(newStudent);

            student.Id = result.Id;

            return Ok(student);
        }

        [HttpPost("/editStudent/{id}")]
        public async Task<IActionResult> EditStudentProfile(CreateStudentDTO student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student newStudent = new()
            {
                Name = student.Name,
                LastName = student.LastName,
                BirthDate = student.BirthDate,
                IsBudget = student.IsBudget,
                Department = student.Department,
                Direction = student.Direction,
                EducationForm = student.EducationForm,
                EducationType = student.EducationType,
                Faculty = student.Faculty,
                GroupNumber = student.GroupNumber,
                Patronymic = student.Patronymic,
                UserId = student.UserId,
                Year = student.Year,
            };

            await _studentRepository.Update(newStudent);

            return Ok(student);
        }

        [HttpPost("/deleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudentProfile(int id)
        {
            await _studentRepository.Delete(id);

            var deletedStudent = _studentRepository.GetById(id);

            if (deletedStudent is null)
                return NotFound();

            return Ok();
        }

        #endregion
    }
}
