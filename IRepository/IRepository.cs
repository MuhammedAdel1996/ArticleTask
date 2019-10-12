using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleTask.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetEntity(int id);
        IEnumerable<TEntity> GetAllEntities();
        void AddEntity(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void RemoveEntity(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void complete();
    }
}
