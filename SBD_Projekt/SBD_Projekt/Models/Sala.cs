using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Sala
    {
        [Key]
        public int id_sala { get; set; }
        [Required]
        public string Rodzaj { get; set; }
        [Required]
        public string Wielkosc { get; set; }
    }
}
