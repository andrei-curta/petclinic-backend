using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models.DTO
{
    public class ProgramarePost_DTO
    {
        public long AnimalId { get; set; }

        public DateTime DataConsultatie { get; set; }
        public long MedicId { get; set; }

        [MaxLength(1000)]
        public string Observatii { get; set; }

        public long? StatusProgramareId { get; set; }

        public List<long> ServiciiId { get; set; }
    }
}
