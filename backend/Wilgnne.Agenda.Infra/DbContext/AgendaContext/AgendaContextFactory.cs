using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext
{
    public class AgendaContextFactory : IDesignTimeDbContextFactory<AgendaContext>
    {
        public AgendaContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Join(Directory.GetCurrentDirectory(), "..", "Wilgnne.Agenda.Api"))
                    .AddJsonFile("appsettings.Development.json")
                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AgendaContext>();

            var connectionString = configuration
                        .GetConnectionString("AgendaContext");

            optionsBuilder.UseSqlServer(connectionString);

            return new AgendaContext(optionsBuilder.Options);
        }
    }
}
