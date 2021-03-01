﻿using FrameworkWorkShop.Business.Abstract;
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

namespace FrameworkWorkShop.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;
        private readonly IQueryableRepository<Product> _queryable;

        public ProductManager(IProductDal prodcutDal, IQueryableRepository<Product> queryable)
        {
            _productdal = prodcutDal;
            _queryable = queryable;
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            IValidator<Product> xc = (IValidator<IEntity>)Activator.CreateInstance(typeof(ProductValidator));
            return _productdal.Add(product);
        }

        public List<Product> GetAll()
        {
            //_queryable.Table.Where(t => t.CategoryId == 1).ToList();
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
        public void TansactionalOperation(Product abc, Product xyz)
        {
            _productdal.Add(abc);
            //business codes
            _productdal.Update(xyz);

        }
    }
}
