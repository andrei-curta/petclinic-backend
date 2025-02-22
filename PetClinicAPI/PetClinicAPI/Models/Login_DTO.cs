﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Login_DTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
