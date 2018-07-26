using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Models
{
    public class Picture
    {
        public int PictureId { get; set; }

        public string FileName { get; set; }

        public virtual Product Product { get; set; }
    }
}
