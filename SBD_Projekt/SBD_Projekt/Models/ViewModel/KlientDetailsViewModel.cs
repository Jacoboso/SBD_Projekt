using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class KlientDetailsViewModel
    {
        public int id_klient { get; set; }

        public Osoba Prawnik { get; set; }
        public Osoba Klient { get; set; }
        public Specjalizacja Prawnik_Specjalizacja { get; set; }
        public Adres Klient_Adres { get; set; }
    }
}
