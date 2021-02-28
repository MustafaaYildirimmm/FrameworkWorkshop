using FrameworkWorkShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Core.DataAccess.NHibernate
{
    public class NhQueryableRepository<TEntity> : IQueryableRepository<TEntity> where TEntity:class,IEntity,new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<TEntity> _entites;
        public NhQueryableRepository(NHibernateHelper nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }
        public IQueryable<TEntity> Table => this.Entities;

        public virtual IQueryable<TEntity> Entities { get { return _entites ?? (_entites = _nHibernateHelper.OpenSession().Query<TEntity>()); } }
    }
}
