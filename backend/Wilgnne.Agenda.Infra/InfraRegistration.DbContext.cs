using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Wilgnne.Agenda.Infra.DbContext.AgendaContext;
using Wilgnne.Agenda.Infra.Persistence.Repositories;

namespace Wilgnne.Agenda.Infra
{
    public partial class InfraRegistration
    {
        private static IServiceCollection AddAgendaDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDbContextPool<AgendaContext>(
                    (s, o) => o.UseSqlServer(configuration.GetConnectionString("AgendaContext"))
                               .UseLoggerFactory(s.GetRequiredService<ILoggerFactory>()))
                .AddHostedService<AgendaMigrationService>()
                .AddRepositories();
        }
    }
}
