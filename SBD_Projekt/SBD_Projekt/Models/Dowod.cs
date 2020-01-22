using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Dowod
    {
        [Key]
        public int id_dowod { get; set; }
        [Required]
        public string Nazwa { get; set; }
        [Required]
        public string Typ { get; set; }

        public int id_rozprawy { get; set; }
    }
}
