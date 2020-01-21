using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Godziny
    {

        [Key]
        public int id_godziny { get; set; }
        [Required]
        public DateTime OdGodziny { get; set; }
        [Required]
        public DateTime DoGodziny { get; set; }
    }
}
