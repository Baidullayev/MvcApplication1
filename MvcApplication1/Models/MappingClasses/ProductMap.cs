using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;
namespace MvcApplication1.Models
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(c => c.Id).Not.Nullable();
            Map(c => c.Name).Not.Nullable();
            References(f => f.StyleId).Column("StyleId").Not.Nullable();            
            Map(c => c.Quantity);
            References(f => f.FirmId).Column("FirmId").Not.Nullable();
            Map(c => c.Description);
            Map(c => c.RealizeTime).CustomSqlType("datetime");
            Map(c => c.HasDiscount);
            Map(c => c.Prise).Not.Nullable();
        }
    }
}