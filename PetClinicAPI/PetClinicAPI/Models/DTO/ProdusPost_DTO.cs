using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models.DTO
{
    public class ProdusPost_DTO
    {
        [MaxLength(250)]
        public string Nume { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Pret { get; set; }

        public List<long> SpeciiTintaId { get; set; }

        [Required]
        public long CategorieProdusId { get; set; }
    }
}
