using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RentACar.Core.Entities;

namespace RentACar.Core.DataAccess
{
    /// <summary>
    /// Generic entity framework class for any database table
    /// </summary>
    /// <typeparam name="TEntity">Entity should be class and must implemented by IEntity</typeparam>
    /// <typeparam name="TContext">Context must be implemented by DbContext</typeparam>
    public class EfEntityRepositoryBase<TEntity,TContext> : IEntityRepository<TEntity>
    where TEntity:class,IEntity,new()
    where TContext:DbContext,new()
    {
        public TEntity Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(entity=>entity.Id==id).FirstOrDefault();
            }
        }

        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var currentUser = context.Entry<TEntity>(entity);
                currentUser.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        // Data will be saved in the database with the UnitOfWork pattern. 
    }
}
