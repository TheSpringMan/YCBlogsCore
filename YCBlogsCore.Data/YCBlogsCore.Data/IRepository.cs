using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace YCBlogsCore.Data
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity:class where TPrimaryKey:struct
    {
        TEntity Insert(TEntity entity);

        void Insert(params TEntity[] entities);

        void Insert(IEnumerable<TEntity> entities);

        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task InsertAsync(params TEntity[] entities);

        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));

        void Update(TEntity entity);

        void Update(params TEntity[] entities);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TPrimaryKey id);

        void Delete(TEntity entity);

        void Delete(params TEntity[] entities);

        void Delete(IEnumerable<TEntity> entities);

        bool Exists(Expression<Func<TEntity, bool>> expression);

        IQueryable<TEntity> GetAll();
    }
}
