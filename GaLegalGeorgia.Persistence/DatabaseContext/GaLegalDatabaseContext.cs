using GaLegalGeorgia.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Persistence.DatabaseContext
{
    public class GaLegalDatabaseContext : DbContext
    {
        public GaLegalDatabaseContext(DbContextOptions<GaLegalDatabaseContext> options) : base(options)
        {
        }
        public DbSet<PracticeArea> PracticeAreas { get; set; }
        public DbSet<ConsultationRequest> ConsultationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GaLegalDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
