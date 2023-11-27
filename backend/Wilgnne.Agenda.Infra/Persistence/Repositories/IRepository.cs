using System.Linq.Expressions;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    public interface IInsertRespository<T>
    {
        public Task<T> Insert(T entity);
    }

    public interface IGetAllRespotory<T>
    {
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
    }

    public interface IEditRepository<T>
    {
        public Task Edit(Guid Id, object item);
    }

    public interface IRepository<T> : IInsertRespository<T>, IGetAllRespotory<T>, IEditRepository<T>
    {

    }
}
