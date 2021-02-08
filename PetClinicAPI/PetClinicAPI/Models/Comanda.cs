using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Comanda
    {
        public long Id { get; set; }

        public ICollection<ProdusComanda> ProduseComanda { get; set; }

        public Utilizator Utilizator { get; set; }
        public string UtilizatorId { get; set; }

        public decimal Total { get; private set; }

        // public decimal UpdateTotal()
        // {
        //     Produse?.Sum(p => p.Pret) ?? 0; }
        // }
    }
}