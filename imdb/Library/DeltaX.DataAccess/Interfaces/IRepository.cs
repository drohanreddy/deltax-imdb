using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.DataAccess.Interfaces
{
    public interface IRepository<TEntity, IdType>
    where TEntity : DeltaX.DataAccess.Entities.Entity<IdType>
    {
        Task<IEnumerable<TEntity>> GetAll();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByID(IdType id);
        Task Insert(TEntity entity);
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Delete(IdType[] ids);
        TEntity InsertAndReturnEntity(TEntity entityToUpdate);
        TEntity UpdateAndReturnEntity(TEntity entityToUpdate);
    }
}
