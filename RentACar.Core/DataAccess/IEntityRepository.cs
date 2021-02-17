using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RentACar.Core.Entities;

namespace RentACar.Core.DataAccess
{
    /// <summary>
    /// Generic class for all database table
    /// </summary>
    /// <typeparam name="T">Entity should be class and must implemented by IEntity</typeparam>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
