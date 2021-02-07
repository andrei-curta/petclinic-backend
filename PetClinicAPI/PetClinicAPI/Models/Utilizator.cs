using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PetClinicAPI.Models
{
    public class Utilizator : IdentityUser
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