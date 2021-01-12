using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Rasa
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nume { get; set; }

        public Specie Specie { get; set; }
    }
}
