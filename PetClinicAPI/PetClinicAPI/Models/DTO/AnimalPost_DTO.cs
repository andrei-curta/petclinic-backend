using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models.DTO
{
    public class AnimalPost_DTO
    {

        [MaxLength(250)]
        public string Nume { get; set; }

        [Required(ErrorMessage = "{0} is mandatory")]
        public string StapanId { get; set; }

        public long? RasaId { get; set; }

    }
}
