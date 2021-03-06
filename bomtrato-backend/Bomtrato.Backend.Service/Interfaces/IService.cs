using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bomtrato.Backend.Service.Interfaces
{
    public interface IService<T>
    {
        T GetId(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

        void Update(T entidade);

        int Save();

    }
}
