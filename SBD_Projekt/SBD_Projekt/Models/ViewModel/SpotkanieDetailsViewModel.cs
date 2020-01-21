using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class SpotkanieDetailsViewModel
    {

        public int id_spotkanie { get; set; }
        public Sala Sala { get; set; }
        public Godziny Godziny { get; set; }
        public Osoba Prawnik { get; set; }
        public Osoba Klient { get; set; }
    }
}
