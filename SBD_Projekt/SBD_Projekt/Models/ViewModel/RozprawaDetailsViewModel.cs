using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_Projekt.Models.ViewModel
{
    public class RozprawaDetailsViewModel
    {
        public int id_rozprawa { get; set; }

        public Godziny Godziny { get; set; }

        public Wydzial Wydzial { get; set; }
        public Osoba Sedzia { get; set; }
        public Osoba Prawnik { get; set; }
        public Osoba Klient { get; set; }

        public List<Dowod> Dowody { get; set; }

    }
}
