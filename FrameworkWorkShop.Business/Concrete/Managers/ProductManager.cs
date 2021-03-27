using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Business.ValidationRules.FluentValidation;
using FrameworkWorkShop.DataAccess.Abstract;
using FrameworkWorkShop.Entities.Concrete;
using FrameworkWorkShop.Core.Aspects.PostSharp;
using System.Collections.Generic;
using FluentValidation;
using System;
using FrameworkWorkShop.Core.Entities;
using FrameworkWorkShop.Core.DataAccess;
using System.Linq;
using System.Transactions;
using FrameworkWorkShop.Core.Aspects.PostSharp.TransactionAspects;
using FrameworkWorkShop.Core.Aspects.PostSharp.CacheAspects;
using FrameworkWorkShop.Core.CrossCuttingConcerns.Caching.Microsoft;
using FrameworkWorkShop.Core.CrossCuttingConcerns.Logging.Log4Net;
using FrameworkWorkShop.Core.Aspects.PostSharp.LogAspects;
using FrameworkWorkShop.Core.Aspects.PostSharp.ExceptionAspects;
using FrameworkWorkShop.Core.Aspects.PostSharp.PerformanceAspects;
using System.Threading;

namespace FrameworkWorkShop.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;
        private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal prodcutDal)
        {
            _productdal = prodcutDal;
        }

        //public ProductManager(IQueryableRepository<Product> queryable)
        //{
        //    _queryable = queryable;
        //}

        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product product)
        {
          
            return _productdal.Add(product);
        }

        [CacheAspect(typeof(MemoryCacheManager),120)]
        [PerformanceCounterAspect(2)]
        public List<Product> GetAll()
        {
            //_queryable.Table.Where(t => t.CategoryId == 1).ToList();
            Thread.Sleep(3000);
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

        [TransactionScopeAspect]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void TransactionalOperation(Product abc, Product xyz)
        {
            _productdal.Add(abc);
            //business codes
            _productdal.Update(xyz);

        }
    }
}
