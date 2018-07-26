using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public int? Quantity { get; set; }
        public int? UnitPrice { get; set; }
        public int? Price { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order  Order { get; set; }






    }
}
