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
        public string Nazwa { get; set; }
        public string Typ { get; set; }
    }
}
