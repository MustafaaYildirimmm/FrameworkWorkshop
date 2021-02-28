using FrameworkWorkShop.DataAccess.Concrete.EntityFramework;
using FrameworkWorkShop.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkWorkShop.DataAccess.Test.EfTests
{
    /// <summary>
    /// Summary description for EfTests
    /// </summary>
    [TestClass]
    public class EfTest
    {

        [TestMethod]
        public void GEt_All_REturns_all_Products()
        {
            var productDal = new EfProductDal();
            var result = productDal.GetList();

            Assert.AreEqual(77, result.Count);
        }

        [TestMethod]
        public void GEt_All_With_paramaters_REturns_filtered_Products()
        {
            var productDal = new EfProductDal();
            var result = productDal.GetList(p=> p.ProductName.Contains("ab"));

            Assert.AreEqual(4, result.Count);
        }
    }
}
