namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> Insert(T entity);
    }
}
