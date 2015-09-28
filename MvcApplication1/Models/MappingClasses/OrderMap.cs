using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;
namespace MvcApplication1.Models
{
    public class OrderMap : ClassMap<Order>
    {
        public OrderMap()
        {
            Id(c => c.Id).Not.Nullable();
            References(f => f.ProductId).Column("ProductId").Not.Nullable();
            Map(c => c.Quantity).Not.Nullable();
            Map(c => c.OrderTime).CustomSqlType("datetime").Not.Nullable();
            Map(c => c.CustomerName).Not.Nullable();
            Map(c => c.Address).Not.Nullable();
            Map(c => c.PhoneNumber).Not.Nullable();
            Map(c => c.DeliverTime).Not.Nullable().CustomSqlType("datetime");
            Map(c => c.AddInfo);
            Map(c => c.Status);
        }
    }
}