using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Obsluga
    {
        [Key]
        public int id_obsluga { get; set; }
        public int id_osoba { get; set; }
        public int id_zarobki { get; set; }
        public int id_godziny { get; set; }
        public string typ { get; set; }
    }
}
