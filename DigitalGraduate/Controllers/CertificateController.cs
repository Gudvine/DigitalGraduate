using DigitalGraduate.Data.Context;
using DigitalGraduate.Data.DAL.CertificateApplication;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.Certificates;
using DigitalGraduate.Data.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Security.Claims;

namespace DigitalGraduate.Controllers
{
    [ApiController]
    [Route("[api]")]
    public class CertificateController : ControllerBase
    {
        readonly UserManager<ApiUser> _userManager;
        readonly ApplicationDbContext _context;
        private CertificateApplicationRepository _certificateRepository;

        public CertificateController(UserManager<ApiUser> userManager, ApplicationDbContext context, CertificateApplicationRepository certificateRepository)
        {
            _userManager = userManager;
            _context = context;
            _certificateRepository = certificateRepository;
        }

        ////[Authorize(Roles = "Admin,Student,Employee")]
        //[HttpPost("/orderCertificate")]
        //public async Task<IActionResult> CreateCertificateApplication(ApplicationCertificateModel certificateModel)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    CertificateApplication application = new()
        //    {
        //        Count = certificateModel.Count,
        //        ProvideTo = certificateModel.SpaceRequirement,
        //        WithOfficialSeal = certificateModel.NeedOfficialSeal,
        //        StudentId = certificateModel.UserId
        //    };

        //    _certificateRepository.Create(application);

        //    return Ok();
        //}

        ////[Authorize(Roles = "Admin,Employee")]
        //[HttpGet("/certificateApplications/all")]
        //public IEnumerable<CertificateApplication> GetAllCertificateApplications()
        //{
        //    return _certificateRepository.GetAll();
        //}
    }
}
