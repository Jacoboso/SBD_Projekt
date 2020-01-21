using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SBD_Projekt.Models
{
    public class Adres
    {
        [Key]
        public int id_adres { get; set; }

        [Required]
        public string Kraj { get; set; }
        [Required]
        public string Miasto { get; set; }
        [Required]
        public string Województwo { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public string Nr_domu { get; set; }
        [Required]
        public string Nr_miszkania { get; set; }

    }
}
