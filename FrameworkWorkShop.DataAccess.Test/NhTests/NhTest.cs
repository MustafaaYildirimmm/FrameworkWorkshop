using FrameworkWorkShop.DataAccess.Concrete.NHibernate;
using FrameworkWorkShop.DataAccess.Concrete.NHibernate.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkWorkShop.DataAccess.Test.NhTests
{
    /// <summary>
    /// Summary description for NhTest
    /// </summary>
    [TestClass]
    public class NhTest
    {


        [TestMethod]
        public void GEt_All_REturns_all_Products()
        {
            var productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void GEt_All_With_paramaters_REturns_filtered_Products()
        {
            var productDal = new NhProductDal(new SqlServerHelper());
            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
