using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class ProdusComanda
    {
        public long  Id { get; set; }
        public uint Cantitate { get; set; }
        public long ProdusId { get; set; }
        public Produs Produs { get; set; }
        public long ComandaId { get; set; }
    }
}
