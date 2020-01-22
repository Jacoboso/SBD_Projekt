using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SBD_Projekt.Models
{
    public class Rozprawa
    {
        [Key]
        public int id_rozprawa { get; set; }

        public int id_godziny { get; set; }

        public int id_wydzial { get; set; }
        public int id_sedzia { get; set; }
        public int id_prawnik { get; set; }
        public int id_klient { get; set; }

    }
}
