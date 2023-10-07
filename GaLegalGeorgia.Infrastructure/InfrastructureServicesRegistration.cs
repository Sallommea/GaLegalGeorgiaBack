using GaLegalGeorgia.Application.Contracts.Email;
using GaLegalGeorgia.Application.Contracts.Logging;
using GaLegalGeorgia.Application.Models.Email;
using GaLegalGeorgia.Infrastructure.EmailService;
using GaLegalGeorgia.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GaLegalGeorgia.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}