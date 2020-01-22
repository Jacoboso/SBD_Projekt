using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class WydzialDetailsViewModel
    {
        public int id_wydzial { get; set; }

        public string nazwa { get; set; }

        public Budynek Budynek { get; set; }

      
    }
}
