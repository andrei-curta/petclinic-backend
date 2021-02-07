using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetClinicAPI.Models
{
    public class Comanda
    {
        public long Id { get; set; }

        public ICollection<Produs> Produse { get; set; }

        // public Utilizator Utilizator { get; set; }


        public decimal Total
        {
            get { return Produse.Sum(p => p.Pret); }
        }
       
    }
}