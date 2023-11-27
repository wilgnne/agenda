using Microsoft.Extensions.DependencyInjection;
using Wilgnne.Agenda.Domain.Entities;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    internal static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddRepository<SchoolSubject, SchoolSubjectRepository>()
                .AddRepository<SchoolSubjectEvent, SchoolSubjectEventRepository>()
                .AddRepository<ApplicationUser, ApplicationUserRepository>();
        }

        private static IServiceCollection AddRepository<E, T>(this IServiceCollection services)
         where T : class, IRepository<E>
        {
            return services
                .AddScoped<IRepository<E>, T>()
                .AddScoped<IInsertRespository<E>>(x => x.GetRequiredService<IRepository<E>>())
                .AddScoped<IGetAllRespotory<E>>(x => x.GetRequiredService<IRepository<E>>())
                .AddScoped<IEditRepository<E>>(x => x.GetRequiredService<IRepository<E>>());
        }
    }
}
