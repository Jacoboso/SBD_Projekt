using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Specjalizacja
    {
        [Key]
        public int id_specjalizacja { get; set; }
        public string nazwa { get; set; }
        public string doswiadczenie { get; set; }
    }
}
