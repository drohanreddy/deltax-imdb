using DeltaX.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeltaX.DataAccess.Implementation
{
    public class Repository<TEntity, IdType> : IRepository<TEntity, IdType>
        where TEntity : DeltaX.DataAccess.Entities.Entity<IdType>
    {
        internal DXContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DXContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                return dbSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {

            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity GetByID(IdType id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public virtual void Delete(object id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(IdType[] ids)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(ids);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void InsertOrUpdate(TEntity entityToUpdate)
        {
            try
            {

                // dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Modified;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public virtual TEntity InsertAndReturnEntity(TEntity entityToUpdate)
        {
            try
            {
                // dbSet.Attach(entityToUpdate);
                context.Entry(entityToUpdate).State = EntityState.Added;
                return entityToUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public virtual TEntity UpdateAndReturnEntity(TEntity entityToUpdate)
        {
            try
            {
                context.Entry(entityToUpdate).State = EntityState.Modified;
                //  dbSet.Attach(entityToUpdate);

                return dbSet.Find(entityToUpdate.Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
