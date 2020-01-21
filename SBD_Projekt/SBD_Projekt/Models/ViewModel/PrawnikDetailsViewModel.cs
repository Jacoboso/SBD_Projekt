using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class PrawnikDetailsViewModel
    {
        public int id_prawnik { get; set; }
        public Osoba Osoba;
        public Adres Adres;
        public Godziny Godziny;
        public Zarobki Zarobki;
        public Specjalizacja Specjalizacje;
    }
}
