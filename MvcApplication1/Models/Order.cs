using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class Order
    {
        public virtual int Id { get; set; }
        public virtual Product ProductId { get; set; }
        public virtual int Quantity { get; set; }
        public virtual DateTime OrderTime { get; set; }
        public virtual String CustomerName { get; set; }
        public virtual String Address { get; set; }
        public virtual String PhoneNumber { get; set; }
        public virtual DateTime DeliverTime { get; set; }
        public virtual String AddInfo { get; set; }
        public virtual String Status { get; set; }
        
    }
}