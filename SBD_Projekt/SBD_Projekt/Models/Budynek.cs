using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Budynek
    {
        [Key]
        public int id_budynek { get; set; }
        [Required]
        public string Miasto { get; set; }
        [Required]
        public string Ulica { get; set; }
        [Required]
        public string KodPocztowy { get; set; }
        [Required]
        public string NrBudynku { get; set; }
    }
}
