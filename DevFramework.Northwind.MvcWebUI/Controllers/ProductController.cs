using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
           
            
            var model = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            
            return View(model);
        }

        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "YagoPhone",
                QuantityPerUnit = "1",
                UnitPrice = 21

            });
            return "Added!";
        }
        public string Add2()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                ProductName = "SevimPhone",
                QuantityPerUnit = "1",
                UnitPrice = 23

            });
            return "Added Sevim's Phone!";
        }
    }
}