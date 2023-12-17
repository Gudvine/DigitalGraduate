using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.File;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {
        private IRepository<FileInstance> _fileRepository;

        public FileController(IRepository<FileInstance> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        [HttpGet("all")]
        public async Task<IEnumerable<FileInstance>> GetAllFiles()
        {
            var allFiles = await _fileRepository.GetAll();

            return allFiles;
        }

        [HttpPost("/{id}/get")]
        public IActionResult GetFile(int id)
        {
            var file = _fileRepository.GetById(id);

            if (file is null)
                return NotFound("Файл с таким Id не найден");

            return Ok(file);
        }

        [HttpPost("/{id}/delete")]
        public IActionResult DeleteFile(int id)
        {
            _fileRepository.Delete(id);

            return Ok();
        }

        [HttpPost("/create")]
        public IActionResult CreateFile(FileInstance file)
        {
            return Ok();
        }
    }
}
