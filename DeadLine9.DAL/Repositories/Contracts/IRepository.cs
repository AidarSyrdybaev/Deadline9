using DeadLine9.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeadLine9.DAL.Repositories.Contracts
{
    public interface IRepository<T> where T: class, IEntity
    {
        public T GetById(int Id);

        public void Remove(T entity);

        public T Create(T entity);

        public IEnumerable<T> GetAll();

        public T Update(T entity);
    }
}
