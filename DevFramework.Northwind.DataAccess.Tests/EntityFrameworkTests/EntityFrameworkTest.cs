﻿using System;
using System.Text;
using System.Collections.Generic;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevFramework.Northwind.DataAccess.Tests.EntityFrameworkTests
{
   
    [TestClass]
    public class EntityFrameworkTest
    {

        [TestMethod]
        public void Get_all_returns_all_products()
        {
            EfProductDal productDal=new EfProductDal();

            var result = productDal.GetList();
            
            Assert.AreEqual(78,result.Count);
        }

        [TestMethod]
        public void Get_all_with_paramater_returns_filtered_products()
        {
            EfProductDal productDal=new EfProductDal();

            var result = productDal.GetList(p => p.ProductName.Contains("ab"));

            Assert.AreEqual(4,result.Count);
        }
    }
}
