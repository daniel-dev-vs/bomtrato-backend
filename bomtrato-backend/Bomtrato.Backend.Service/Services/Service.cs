using Bomtrato.Backend.Data.Interfaces;
using Bomtrato.Backend.Data.Repositories;
using Bomtrato.Backend.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bomtrato.Backend.Service.services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> Repository;


        public Service(IRepository<T> repository) 
        {
            this.Repository = repository;
        
        }
        public void Add(T entidade)
        {
            Repository.Add(entidade);
        }

        public void AddRange(IEnumerable<T> entidades)
        {
            Repository.AddRange(entidades);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Repository.Find(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return Repository.GetAll();
        }

        public T GetId(int id)
        {
            return Repository.GetId(id);
        }

        public void Remove(T entidade)
        {
            Repository.Remove(entidade);
        }

        public void RemoveRange(IEnumerable<T> entidades)
        {
            Repository.RemoveRange(entidades);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return Repository.SingleOrDefault(predicate);
        }

        public int Save() 
        {
            return Repository.Save();
        }

        public void Update(T entidade)
        {
            Repository.Update(entidade);
        }
    }
}
