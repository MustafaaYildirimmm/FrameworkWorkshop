using FrameworkWorkShop.Business.Abstract;
using FrameworkWorkShop.Entities.Concrete;
using FrameworkWorkShop.MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrameworkWorkShop.MVCUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var model = new ProductListViewModel()
            {
                Products = _productService.GetAll()
            };
            return View(model);
        }

        public ActionResult Add()
        {
            _productService.Add(new Product() { 
                ProductName="test",
                QuantityPerUnit="25",
                UnitPrice=25,
                CategoryId=1
            });
            return View("Product Added");
        }

        public string AddUpdate()
        {
            _productService.TransactionalOperation(
            new Product()
            {
                ProductName = "gsm",
                QuantityPerUnit = "25",
                UnitPrice = 2,
                CategoryId = 1
            },
            new Product()
            {
                ProductName = "computer",
                QuantityPerUnit = "24",
                UnitPrice = 30,
                CategoryId = 1,
                ProductId=2
            });

            return "Do It!";
        }
    }
}