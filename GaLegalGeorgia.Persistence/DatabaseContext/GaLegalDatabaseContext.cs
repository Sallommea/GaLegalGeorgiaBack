using GaLegalGeorgia.Domain;
using Microsoft.EntityFrameworkCore;

namespace GaLegalGeorgia.Persistence.DatabaseContext
{
    public class GaLegalDatabaseContext : DbContext
    {
        public GaLegalDatabaseContext(DbContextOptions<GaLegalDatabaseContext> options) : base(options)
        {
        }
        public DbSet<PracticeArea> PracticeAreas { get; set; }
        public DbSet<ConsultationRequest> ConsultationRequests { get; set; }

        public DbSet<AdminModels> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GaLegalDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
