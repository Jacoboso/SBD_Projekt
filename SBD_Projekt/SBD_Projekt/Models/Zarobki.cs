using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Zarobki
    {
        [Key]
        public int id_zarobki { get; set; }
        [Required]
        public float zarobek { get; set; }
        [Required]
        public float premia { get; set; }
    }
}
