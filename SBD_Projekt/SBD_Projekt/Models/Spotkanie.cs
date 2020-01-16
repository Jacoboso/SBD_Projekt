using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Spotkanie
    {
        [Key]
        public int id_spotkanie { get; set; }
        public int id_sali { get; set; }
        public int id_godziny { get; set; }
        public int id_prawnik { get; set; }
        public int id_klient { get; set; }
    }
}
