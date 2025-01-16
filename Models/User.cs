﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADCourseWork.Models;  // Ensure this is included at the top of the file

namespace ADCourseWork.Models
{
    public class User
    {
        [Key]
        //public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string Currency { get; set; }





    }
}


