using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.UserData;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public virtual DbSet<TrainingArea> TrainingAreas { get; set; }
        public virtual DbSet<ScientificSpeciality> ScientificSpecialities { get; set; }
        public virtual DbSet<GraduateProgram> GraduatePrograms { get; set; }
        public virtual DbSet<GraduateStudent> GraduateStudents { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UniversityEvent> UniversityEvents { get; set; }
        public virtual DbSet<Grant> Grants { get; set; }
        public virtual DbSet<CertificateApplication> CertificateApplications { get; set; }
    }
}
