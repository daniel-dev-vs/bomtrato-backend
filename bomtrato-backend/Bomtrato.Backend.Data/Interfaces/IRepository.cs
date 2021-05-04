using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bomtrato.Backend.Data.Interfaces
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
     
        void Update(T entidade);

        int Save();
    }
}

