using Microsoft.Extensions.DependencyInjection;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    internal static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IRepository<SchoolSubject>, SchoolSubjectRepository>()
                .AddScoped<IRepository<SchoolSubjectEvent>, SchoolSubjectEventRepository>();
        }
    }
}
