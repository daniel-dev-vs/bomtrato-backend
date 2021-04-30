using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace bomtrato.backend.data.interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetId(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entidade);
        void AddRange(IEnumerable<T> entidades);

        void Remove(T entidade);
        void RemoveRange(IEnumerable<T> entidades);

    }
}
