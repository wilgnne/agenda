using System.Linq.Expressions;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.DbContext.AgendaContext;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    public class SchoolSubjectEventRepository(AgendaContext context) : IRepository<SchoolSubjectEvent>
    {
        public async Task<SchoolSubjectEvent> Insert(SchoolSubjectEvent entity)
        {
            context.SchoolSubjectEvents.Add(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public Task<IEnumerable<SchoolSubjectEvent>> GetAll(Expression<Func<SchoolSubjectEvent, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = context.SchoolSubjectEvents.Where(predicate);

                return entities.AsEnumerable();
            });
        }
    }
}
