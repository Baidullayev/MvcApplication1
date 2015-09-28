using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;
namespace MvcApplication1.Models
{
    public class FirmMap : ClassMap<Firm>
    {
        public FirmMap()
        {
            Id(c => c.Id).Not.Nullable().Not.Nullable();
            Map(c => c.Name).Not.Nullable();
            Map(c => c.Address).Not.Nullable();
            Map(c => c.PhoneNumber);
            Map(c => c.Email);
            Map(c => c.AddInfo);
        }
    }
}