using DigitalGraduate.Data.DAL;
using DigitalGraduate.Data.DAL.File;
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
    }
}
