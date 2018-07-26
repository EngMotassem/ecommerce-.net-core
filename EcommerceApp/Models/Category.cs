using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            SubCategories = new HashSet<SubCategory>();

        }

        public int categoryId { get; set; }
        [Required(ErrorMessage ="category name is required ")]
        [StringLength(50)]
        [Display(Name ="category name")]
         public string  categoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }





    }
}
