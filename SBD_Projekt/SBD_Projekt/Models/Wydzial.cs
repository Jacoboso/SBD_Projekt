using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Wydzial
    {
        [Key]
        public int id_wydzial { get; set; }
        public int id_budynku { get; set; }

        [Required]
        public string nazwa { get; set; }
    }
}
