using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext
{
    internal class AgendaMigrationService(IServiceProvider serviceProvider, ILogger<AgendaMigrationService> logger) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Starting migration...");
            logger.LogInformation("Getting AgendaContext...");
            using IServiceScope scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AgendaContext>();

            await context.Database.MigrateAsync(stoppingToken);

            logger.LogInformation("Ending migration...");
        }
    }
}
