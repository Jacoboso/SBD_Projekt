using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class OblugaDetailsViewModel
    {
        public int id_obsluga { get; set; }
        public Adres Adres { get; set; }
        public Osoba Osoba { get; set; }
        public Zarobki Zarobki { get; set; }
        public Godziny Godziny { get; set; }
        public string typ { get; set; }
    }
}
