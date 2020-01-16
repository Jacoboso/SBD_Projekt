using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SBD_Projekt.Models
{
    public class Osoba
    {
        [Key]
        public int id_osoba { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public int id_adres { get; set; }
        public string Telefon { get; set; }
    }
}


