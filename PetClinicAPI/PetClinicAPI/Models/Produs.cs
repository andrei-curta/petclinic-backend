using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Produs
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nume { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Pret { get; set; }

        public ICollection<Specie> SpeciiTinta { get; set; }
        
        public CategorieProdus CategorieProdus { get; set; }
    }
}
