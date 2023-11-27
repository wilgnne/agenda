using System.Linq.Expressions;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.DbContext.AgendaContext;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories;

public class ApplicationUserRepository(AgendaContext context) : IRepository<ApplicationUser>
{
    public async Task<ApplicationUser> Insert(ApplicationUser entity)
    {
        context.Users.Add(entity);

        await context.SaveChangesAsync();

        return entity;
    }

    public Task<IEnumerable<ApplicationUser>> GetAll(Expression<Func<ApplicationUser, bool>> predicate)
    {
        return Task.Run(() =>
        {
            var entities = context.Users.Where(predicate);

            return entities.AsEnumerable();
        });
    }

    public Task Edit(Guid Id, object item)
    {
        throw new NotImplementedException();
    }
}
