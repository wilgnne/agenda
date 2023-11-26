using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.DbContext.AgendaContext
{
    public class AgendaContext(DbContextOptions<AgendaContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
    {
        public DbSet<ApplicationUser> Users { get; private set; }
        public DbSet<SchoolSubject> SchoolSubjects { get; private set; }
        public DbSet<SchoolSubjectEvent> SchoolSubjectEvents { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(),
                (type) => (type.Namespace ?? "").Contains("Configurations"));
        }
    }
}
