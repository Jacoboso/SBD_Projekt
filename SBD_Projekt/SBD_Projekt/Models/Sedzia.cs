using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Sedzia
    {
        [Key]
        public int id_sedzia { get; set; }
        public int id_osoba { get; set; }
        public int id_wydzial { get; set; }
        public int id_zarobki { get; set; }

    }
}
