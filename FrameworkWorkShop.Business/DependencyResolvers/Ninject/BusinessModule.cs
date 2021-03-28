using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Business.Concrete.Managers;
using FrameworkWorkShop.Core.DataAccess;
using FrameworkWorkShop.Core.DataAccess.EntityFramework;
using FrameworkWorkShop.Core.DataAccess.NHibernate;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.DataAccess.Concrete.EntityFramework;
using FrameworkWorkShop.DataAccess.Concrete.NHibernate.Helpers;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<NorthwindContext>();
            Bind<NHibernateHelper>().To<SqlServerHelper>();
        }
    }
}
