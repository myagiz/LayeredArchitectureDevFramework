using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    public class ProductMap:ClassMap<Product>
    {
        public ProductMap()
        {
            Table(@"Products");

            LazyLoad();

            Id(x => x.ProductId).Column("ProductId");
           
            Map(x => x.CategoryId).Column("CategoryId");
            Map(x => x.ProductName).Column("ProductName");
            Map(x => x.QuantityPerUnit).Column("QuantityPerUnit");
            Map(x => x.UnitPrice).Column("UnitPrice");
        }
    }
}
