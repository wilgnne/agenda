﻿using System.Linq.Expressions;

namespace Wilgnne.Agenda.Infra.Persistence.Repositories
{
    public interface IRepository<T>
    {
        public Task<T> Insert(T entity);
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate);
    }
}
