using System.Linq.Expressions;
using Wilgnne.Agenda.Domain.Entities;
using Wilgnne.Agenda.Infra.DbContext.AgendaContext;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    public class SchoolSubjectRepository(AgendaContext context) : IRepository<SchoolSubject>
    {
        public async Task<SchoolSubject> Insert(SchoolSubject entity)
        {
            context.SchoolSubjects.Add(entity);

            await context.SaveChangesAsync();

            return entity;
        }

        public Task<IEnumerable<SchoolSubject>> GetAll(Expression<Func<SchoolSubject, bool>> predicate)
        {
            return Task.Run(() =>
            {
                var entities = context.SchoolSubjects.Where(predicate);

                return entities.AsEnumerable();
            });
        }
    }
}
