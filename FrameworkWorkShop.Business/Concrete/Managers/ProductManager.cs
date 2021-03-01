using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Business.ValidationRules.FluentValidation;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.Concrete;
using FrameworkWorkShop.Core.Aspects.PostSharp;
using System.Collections.Generic;
using FluentValidation;
using System;
using FrameworkWorkShop.Core.Entities;

namespace FrameworkWorkShop.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;
        public ProductManager(IProductDal prodcutDal)
        {
            _productdal = prodcutDal;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            IValidator<Product> xc = (IValidator<IEntity>)Activator.CreateInstance(typeof(ProductValidator));
            return _productdal.Add(product);
        }

        public List<Product> GetAll()
        {
            return _productdal.GetList();
        }

        public Product GetById(int id)
        {
            return _productdal.SingleOrDefault(t => t.ProductId == id);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            return _productdal.Update(product);
        }
    }
}
