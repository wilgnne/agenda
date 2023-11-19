using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Wilgnne.Agenda.Infra
{
    public static partial class InfraRegistration
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddOpenTelemetryService()
                .AddAgendaDbContext(configuration);
        }

        public static ILoggingBuilder AddInfraLoggings(this ILoggingBuilder logging)
        {
            return logging
                .AddOpenTelemetryLoggings();
        }
    }
}
