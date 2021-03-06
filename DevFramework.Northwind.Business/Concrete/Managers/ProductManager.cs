﻿using System.Collections.Generic;
using System.Threading;
using DevFramework.Core.Aspect.PostSharp.CacheAspects;
using DevFramework.Core.Aspect.PostSharp.LogAspects;
using DevFramework.Core.Aspect.PostSharp.PerformanceAspect;
using DevFramework.Core.Aspect.PostSharp.TransactionAspects;
using DevFramework.Core.Aspect.PostSharp.ValidationAspects;
using DevFramework.Core.CrossCuttingCorners.Caching.Microsoft;
using DevFramework.Core.CrossCuttingCorners.Logging.Log4Net.Loggers;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;
        private IProductService _productServiceImplementation;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        
        [PerformanceCounterAspect(2)]
        public List<Product> GetAll()
        {
            //Thread.Sleep(3000); !! 3 second sleep
            return _productDal.GetList();
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.ProductId == id);
        }

        //[FluentValidationAspect(typeof(ProductValidatior))] HATA VAR GERİ BAK!
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        public Product Add(Product product)
        {
            return _productDal.Add(product);
        }
        [FluentValidationAspect(typeof(ProductValidatior))]
        public Product Update(Product product)
        {
            return _productDal.Update(product);
        }

        public void Delete(Product product)
        {
             _productDal.Delete(product);
        }

        [TransactionScopeAspect]
        public void TransactionOperation(Product product1, Product product2)
        {
            _productDal.Add(product1);
            _productDal.Update(product2);
        }
    }
}
