using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
namespace MvcApplication1.Models
{
    public class Firm
    {
        public virtual int Id {get; set; }
        public virtual String Name { get; set; }
        public virtual String Address { get; set; }
        public virtual String PhoneNumber { get; set; }
        public virtual String Email { get; set; }
        public virtual String AddInfo { get; set; }

    }

    
}