using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;
using FluentNHibernate.Mapping;

namespace DevFramework.Northwind.DataAccess.Concrete.NHibernate.Mapping
{
    public class CategoryMap:ClassMap<Category>
    {
        public CategoryMap()
        {
            Table(@"Categories");
            LazyLoad();

            Id(x => x.CategoryId).Column("CategoryId");

            Map(x => x.CategoryName).Column("CategoryName");
        }
    }
}
