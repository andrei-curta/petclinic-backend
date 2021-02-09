using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class CategorieProdus
    {
        public long Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Nume { get; set; }
    }
}
