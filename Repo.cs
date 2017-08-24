using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Entities;

namespace Data.Common
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly IDataContext Context;
        protected readonly IDbSet<TEntity> DbSet;

        public Repository(IDataContext context)
        {
            Context = context;
            DbSet = context.CreateSet<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return DbSet;
        }

        public virtual IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            return CreateQueryIncluding(includedProperties);
        }

        public virtual TEntity Find(params object[] keyValues)
        {
            if (keyValues == null)
            {
                throw new ArgumentNullException(nameof(keyValues));
            }

            

            return DbSet.Find(keyValues);
        }

        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;

            DbSet.Add(entity);

            SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity.ModifiedDate = DateTime.UtcNow;
            
            DbSet.Attach(entity);

            Context.SetState(entity, EntityState.Modified);

            SaveChanges();
        }

        public virtual void Delete(params object[] keyValues)
        {
            if (keyValues == null)
            {
                throw new ArgumentNullException(nameof(keyValues));
            }

            var entity = Find(keyValues);

            DbSet.Remove(entity);

            SaveChanges();
        }

        public virtual void Detach(TEntity entity)
        {
            Context.SetState(entity, EntityState.Detached);
        }

        public virtual void SaveChanges()
        {
            Context.SaveChanges();
        }

        private IQueryable<TEntity> CreateQueryIncluding(params Expression<Func<TEntity, object>>[] includedProperties)
        {
            IQueryable<TEntity> query = DbSet;

            if (includedProperties != null)
            {
                includedProperties.ToList().ForEach(i => query = query.Include(i));
            }

            return query;
        }

        public IEnumerable<TEntity> ExecuteSqlAndGetCollection(string sql, params object[] paremeters)
        {
            var set = (DbSet<TEntity>) DbSet;

            var result = set.SqlQuery(sql, paremeters).ToList();

            return result;
        }

        public void ExecuteSql(string sql, params object[] parameters)
        {
            var set = (DbSet<TEntity>)DbSet;
            set.SqlQuery(sql, parameters);
        }
    }
}