using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApp.Models
{
    public class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
            Pictures = new HashSet<Picture>();
            CartItems = new HashSet<CartItem>();
            Features = new HashSet<Features>();

        }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "product  name is required ")]
        [StringLength(50)]
        [Display(Name = "product  name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "product  details is required ")]
        [StringLength(250)]
        [Display(Name = "product  details")]
        public string ProductDetails { get; set; }
        public decimal UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public string ProductImagePath { get; set; }

        [NotMapped]
        public IFormFile ProductImage { get; set; }


        public bool IsActive { get; set; }

        public int CartId { get; set; }

        public int FeatureId { get; set; }

        public int CategoryId { get; set; }

        public int? PictureId { get; set; }

        public int OrderLineId { get; set; }



        public virtual Category Category { get; set; }

        public virtual  ICollection <OrderLine> OrderLines{ get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

        public virtual ICollection<Features> Features { get; set; }








    }
}