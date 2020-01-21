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
        [Required]
        public string Imie { get; set; }
        [Required]
        public string Nazwisko { get; set; }

        [Required]
        [StringLength(11)]
        public string Pesel { get; set; }
        public int id_adres { get; set; }

        [Required]
        [StringLength(9)]
        public string Telefon { get; set; }
    }
}


