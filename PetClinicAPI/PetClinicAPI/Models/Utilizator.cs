using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace PetClinicAPI.Models
{
    public class Utilizator :IdentityUser
    {
        public long IdUtilizator { get; set; }

        [MaxLength(250)]
        [NotNull]
        public string Nume { get; set; }

        [MaxLength(250)]
        [NotNull]
        public string Preume { get; set; }

        [MaxLength(13)]
        public string CNP { get; set; }

        public bool eAdmin { get; set; }
    }
}
