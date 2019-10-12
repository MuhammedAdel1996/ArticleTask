using ArticleTask.IRepository;
using ArticleTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArticleTask.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext ApplicationDbContext;
        public Repository(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }
        public void AddEntity(TEntity entity)
        {
            this.ApplicationDbContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.ApplicationDbContext.Set<TEntity>().AddRange(entities);
        }

        public IEnumerable<TEntity> GetAllEntities()
        {
            var result = from e in ApplicationDbContext.Set<TEntity>() select e;
            return result.ToList();
        }

        public TEntity GetEntity(int id)
        {
            var result = ApplicationDbContext.Set<TEntity>().Find(id);
            return result;
        }

        public void RemoveEntity(TEntity entity)
        {
            ApplicationDbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ApplicationDbContext.Set<TEntity>().RemoveRange(entities);
        }


        public void complete()
        {
            ApplicationDbContext.SaveChanges();
        }
    }
}