using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models.DTO
{
    public class ComandaPost_DTO
    {
        [MinLength(1)]
        public List<ProdusComanda_DTO> ProduseComanda { get; set; }

        [Required(ErrorMessage = "{0} is mandatory")]
        public string UtilizatorId { get; set; }
    }
}
