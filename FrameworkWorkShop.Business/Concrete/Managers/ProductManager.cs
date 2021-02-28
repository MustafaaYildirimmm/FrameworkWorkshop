using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Business.ValidationRules.FluentValidation;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.Concrete;
using FrameworkWorkShop.Core.Aspects.PostSharp;
using System.Collections.Generic;

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
