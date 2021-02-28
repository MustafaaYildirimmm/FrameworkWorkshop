using FrameworkWorkShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.DataAccess
{
    public interface IEntityRepository<TEntity> where TEntity : class , IEntity,new()
    {
        List<TEntity> GetList(Expression<Func<TEntity,bool>> filter  = null);

        TEntity SingleOrDefault (Expression<Func<TEntity, bool>> filter);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);  
    }
}
