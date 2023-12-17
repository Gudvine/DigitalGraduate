using DigitalGraduate.Data.DAL.CertificateApplication;
using DigitalGraduate.Data.DAL.Certification;
using DigitalGraduate.Data.DAL.Dissertation;
using DigitalGraduate.Data.DAL.EntranceTest;
using DigitalGraduate.Data.DAL.File;
using DigitalGraduate.Data.DAL.Grant;
using DigitalGraduate.Data.DAL.Patent;
using DigitalGraduate.Data.DAL.Publication;
using DigitalGraduate.Data.DAL.ScientificCompetition;
using DigitalGraduate.Data.DAL.ScientificConference;
using DigitalGraduate.Data.DAL.Student;
using DigitalGraduate.Data.Models.Catalogs;
using DigitalGraduate.Data.Models.UserData;
using Microsoft.EntityFrameworkCore;

namespace DigitalGraduate.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Актуальные модели
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<EntranceTest> EntranceTests { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<FileInstance> Files { get; set; }
        public virtual DbSet<CertificateApplication> CertificateApplications { get; set; }
        public virtual DbSet<Grant> Grants { get; set; }
        public virtual DbSet<Patent> Patents { get; set; }
        public virtual DbSet<ScientificCompetition> ScientificCompetitions { get; set; }
        public virtual DbSet<ScientificConference> ScientificConferences { get; set; }
        public virtual DbSet<Dissertation> Dissertations { get; set; }

        // --------
        public virtual DbSet<TrainingArea> TrainingAreas { get; set; }
        public virtual DbSet<ScientificSpeciality> ScientificSpecialities { get; set; }
        public virtual DbSet<GraduateProgram> GraduatePrograms { get; set; }
        public virtual DbSet<GraduateStudent> GraduateStudents { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Institute> Institutes { get; set; }
        public virtual DbSet<University> Universities { get; set; }
        public virtual DbSet<UniversityEvent> UniversityEvents { get; set; }
    }
}
