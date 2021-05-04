using Bomtrato.Backend.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bomtrato.Backend.Data.Repositories
{
    public class Repository<T> :  IRepository<T> where T : class
    {
        public readonly DbContext Contexto;
        public readonly DbSet<T> DbSet;

        public Repository(DbContext contexto)
        {
            Contexto = contexto;
            DbSet = contexto.Set<T>();
        }
        public void Add(T entidade)
        {
            DbSet.Add(entidade);          
        }

        public void AddRange(IEnumerable<T> entidades)
        {
            DbSet.AddRange(entidades);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetId(int id)
        {

            return  DbSet.Find(id);
        }

        public void Remove(T entidade)
        {
            DbSet.Remove(entidade);
        }

        public void RemoveRange(IEnumerable<T> entidades)
        {
            DbSet.RemoveRange(entidades);
        }

        public T SingleOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
           return DbSet.SingleOrDefault(predicate);
        }

        public void Update(T entidade)
        {           
            DbSet.Update(entidade);          
        }
 

        public int Save() 
        {
            return Contexto.SaveChanges();
        }
        
    }
}
