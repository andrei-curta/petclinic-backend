using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Specie
    {
        public long Id { get; set; }

        [MaxLength(250)]
        public string Nume { get; set; }

        public ICollection<Rasa> Rase { get; set; }

    }
}
