using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Programare
    {
        public long Id { get; set; }
        public Animal Animal { get; set; }
        public DateTime DataConsultatie { get; set; }
        public Medic Medic { get; set; }

        [MaxLength(1000)]
        public string Observatii { get; set; }

        public StatusProgramare StatusProgramare { get; set; }

        public ICollection<Serviciu> Servicii { get; set; }
    }
}
