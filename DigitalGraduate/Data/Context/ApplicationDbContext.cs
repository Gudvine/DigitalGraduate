using DigitalGraduate.Data.Models.Catalogs;
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
    }
}
