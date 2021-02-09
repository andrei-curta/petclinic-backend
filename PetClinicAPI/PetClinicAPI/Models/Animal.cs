using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Animal
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nume { get; set; }

        public Utilizator Stapan { get; set; }

        public string StapanId { get; set; }

        public Rasa Rasa { get; set; }
        public long? RasaId { get; set; }

        public bool Deleted { get; set; }

    }
}
