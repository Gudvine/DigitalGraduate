using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.UserData;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class RootController : ControllerBase
    {
        ApplicationDbContext _context;

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
    }
}
