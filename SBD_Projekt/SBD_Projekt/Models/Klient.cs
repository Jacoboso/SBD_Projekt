using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBD_Projekt.Models
{
    public class Klient
    {
        [Key]
        public int id_klient { get; set; }
        public int id_osoba { get; set; }
        public int id_prawnik { get; set; }
    }
}
