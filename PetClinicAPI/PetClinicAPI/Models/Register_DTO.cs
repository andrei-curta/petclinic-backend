using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Register_DTO
    {
        [EmailAddress]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Nume is required")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Prenume is required")]
        public string Prenume { get; set; }
    }
}
