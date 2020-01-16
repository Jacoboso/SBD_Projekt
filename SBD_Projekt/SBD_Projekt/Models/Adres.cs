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

        public string Kraj { get; set; }
        public string Miasto { get; set; }
        public string Województwo { get; set; }
        public string Ulica { get; set; }
        public string Nr_domu { get; set; }
        public string Nr_miszkania { get; set; }

    }
}
