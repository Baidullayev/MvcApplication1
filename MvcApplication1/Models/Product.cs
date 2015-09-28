using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual String Name { get; set; }
        public virtual Style StyleId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual Firm FirmId { get; set; }
        public virtual String Description { get; set; }
        public virtual DateTime RealizeTime { get; set; }
        public virtual int HasDiscount { get; set; }
        public virtual int Prise { get; set; }
    }
}