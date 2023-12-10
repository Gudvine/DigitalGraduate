using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.DAL.Grant;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.Identity;
using DigitalGraduate.Data.Models.UserData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class RootController : ControllerBase
    {
        readonly ApplicationDbContext _context;
        readonly RoleManager<IdentityRole> _roleManager;

        public RootController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
        }

        [HttpGet("/getAllGrants")]
        public ActionResult<List<Grant>> GetAllGrants()
        {
            return _context.Grants.ToList();
        }

        // TODO: Тестовый контроллер, потом убрать
        [Authorize(Roles = "Admin")]
        [HttpPost("/createRole")]
        public async Task<IActionResult> CreateRole(string name)
        {
            var res = await _roleManager.CreateAsync(new IdentityRole { Name = name });

            if (!res.Succeeded)
                return BadRequest();

            return Ok();
        }

        [HttpGet("/getTrainingAreas")]
        [Authorize(Roles = "Student")]
        public ActionResult<List<TrainingArea>> GetTrainingAreas()
        {
            return _context.TrainingAreas.ToList();
        }

        [HttpGet("/getGraduateStudents")]
        public ActionResult<List<GraduateStudent>> GetGraduateStudents()
        {
            return _context.GraduateStudents.ToList();
        }

        [HttpGet("/getStudent/{id}")]
        public ActionResult<GraduateStudent> GetStudentProfile(int id)
        {
            var student = _context.GraduateStudents.Include(x => x.Department).Where(x => x.Id == id).FirstOrDefault();

            return student == null ? NotFound() : Ok(student);
        }
    }
}
