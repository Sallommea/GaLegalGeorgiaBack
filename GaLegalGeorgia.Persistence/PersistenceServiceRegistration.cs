using GaLegalGeorgia.Application.Contracts.Persistence;
using GaLegalGeorgia.Persistence.DatabaseContext;
using GaLegalGeorgia.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaLegalGeorgia.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices (this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<GaLegalDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GaLegalDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPracticeAreaRepository, PracticeAreaRepository>();
            services.AddScoped<IConsultationRequest, ConsultationRequestRepository>();

            return services;
        }

       
    }
}
