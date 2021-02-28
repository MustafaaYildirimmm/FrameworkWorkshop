using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FrameworkWorkShop.Core.DataAccess.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkWorkShop.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("NorthwindContext")))
                                       .Mappings(t => t.FluentMappings.AddFromAssembly(assembly: Assembly.GetExecutingAssembly()))
                                       .BuildSessionFactory();
        }
    }
}
