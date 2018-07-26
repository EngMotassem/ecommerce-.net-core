﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApp.Services.DTO
{
    public class UserDToForLogin
    {
        [Required]


        public string UserName { get; set; }

        [Required]

        [DataType(DataType.Password)]

        public string PassWord { get; set; }

    }
}
