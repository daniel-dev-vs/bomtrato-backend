using bomtrato.backend.data.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bomtrato.backend.data.repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly DbContext Contexto;

        public Repository(DbContext contexto)
        {
            Contexto = contexto;
        }
        public void Add(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
        }

        public void AddRange(IEnumerable<T> entidades)
        {
            Contexto.Set<T>().AddRange(entidades);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return Contexto.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Contexto.Set<T>().ToList();
        }

        public T GetId(int id)
        {
            return Contexto.Set<T>().Find(id);
        }

        public void Remove(T entidade)
        {
            Contexto.Set<T>().Remove(entidade);
        }

        public void RemoveRange(IEnumerable<T> entidades)
        {
            Contexto.Set<T>().RemoveRange(entidades);
        }

        public T SingleOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return Contexto.Set<T>().SingleOrDefault(predicate);
        }

       
    }
}
