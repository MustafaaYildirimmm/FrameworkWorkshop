using AutoMapper;
using FluentValidation;
using FrameworkWorkShop.Business.Concrete.Managers;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FrameworkWorkShop.Business.Test
{
    [TestClass]
    public class ProductManagerTest
    {
        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Product_Validation_Check()
        {
            Mock<IProductDal> mock = new Mock<IProductDal>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();
            ProductManager productManager = new ProductManager(mock.Object, mockMapper.Object);

            productManager.Add(new Product());

        }
    }
}
