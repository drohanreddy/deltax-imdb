using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeltaX.DataAccess.Interfaces
{
    public interface IRepository<TEntity, IdType>
    where TEntity : DeltaX.DataAccess.Entities.Entity<IdType>
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(IdType id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Delete(IdType[] ids);
        void InsertOrUpdate(TEntity entityToUpdate);
        TEntity InsertAndReturnEntity(TEntity entityToUpdate);
        TEntity UpdateAndReturnEntity(TEntity entityToUpdate);
    }
}
