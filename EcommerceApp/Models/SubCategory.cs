using System.ComponentModel.DataAnnotations;

namespace EcommerceApp.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCatId { get; set; }
        [Required(ErrorMessage = "category name is required ")]
        [StringLength(50)]
        [Display(Name = "category name")]
        public string subCategoryName { get; set; }
        public int categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}