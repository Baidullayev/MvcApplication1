using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;
namespace MvcApplication1.Models
{
    public class StyleMap : ClassMap<Style>
    {
        public StyleMap()
        {
            Id(c => c.Id).Not.Nullable().Not.Nullable();
            Map(c => c.Name).Not.Nullable();
            Map(c => c.Description);
       

        }
    }
}