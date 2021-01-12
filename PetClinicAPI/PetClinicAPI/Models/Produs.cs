using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Produs
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nume { get; set; }

        public decimal Pret { get; set; }

        public ICollection<Specie> SpeciiTinta { get; set; }

        public CategorieProdus CategorieProdus { get; set; }
    }
}
