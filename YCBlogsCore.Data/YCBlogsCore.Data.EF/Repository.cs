using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using YCBlogsCore.Data;

namespace YCBlogsCore.Data.EF
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class where TPrimaryKey : struct
    {
        private readonly DbContext context;
        public Repository(DbContext dbContext)
        {
            this.context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Delete(TPrimaryKey id)
        {
            var entity = this.context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            this.context.Set<TEntity>().Remove(entity);
        }

        public virtual void Delete(params TEntity[] entities)
        {
            this.context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            if (expression == null)
            {
                return this.context.Set<TEntity>().Any();
            }
            else
            {
                return this.context.Set<TEntity>().Any(expression);
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>();
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return this.context.Set<TEntity>().Add(entity).Entity;
        }

        public virtual void Insert(params TEntity[] entities)
        {
            this.context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().AddRange(entities);
        }

        public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return this.context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public virtual Task InsertAsync(params TEntity[] entities)
        {
            return this.context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return this.context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
        }

        public virtual void Update(TEntity entity)
        {
            this.context.Set<TEntity>().Update(entity);
        }

        public virtual void Update(params TEntity[] entities)
        {
            this.context.Set<TEntity>().UpdateRange(entities);
        }

        public virtual void Update(IEnumerable<TEntity> entities)
        {
            this.context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
