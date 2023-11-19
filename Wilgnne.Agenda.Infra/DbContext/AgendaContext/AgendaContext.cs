using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext
{
    public class AgendaContext(DbContextOptions<AgendaContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                (type) => (type.Namespace ?? "").Contains("Configurations"));
        }
    }
}
