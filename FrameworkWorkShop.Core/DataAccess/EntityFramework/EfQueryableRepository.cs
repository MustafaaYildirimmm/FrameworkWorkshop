using FrameworkWorkShop.Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<TEntity> : IQueryableRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private DbContext _context;
        private IDbSet<TEntity> _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> Table => this.Entities;

        protected virtual IDbSet<TEntity> Entities
        {
            get  {  return _entities ?? (_entities = _context.Set<TEntity>()); }
        }
    }
}
