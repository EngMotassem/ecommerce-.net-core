using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class CartItem
    {
        [Key]
        public int CartId { get; set; }
        public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }

        public int? CustomerId { get; set; }
        public int? ProductId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }




    }
}
