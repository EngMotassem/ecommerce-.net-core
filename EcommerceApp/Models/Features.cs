using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Features
    {

        [Key]

        public int FeatureId { get; set; }

        public string FeatureName { get; set; }
        public bool FeatureStatus { get; set; }

        public virtual Product Product { get; set; }

    }
}
