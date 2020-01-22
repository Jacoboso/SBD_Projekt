using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class SedziaDetailsViewModel
    {
        public int id_sedzia { get; set; }
        public Osoba Osoba { get; set; }
        public Wydzial Wydzial { get; set; }
        public Zarobki Zarobki { get; set; }


    }
}
