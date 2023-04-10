using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.UserData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class RootController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public RootController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/getTrainingAreas")]
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

            if (student is not null) 
            {
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
