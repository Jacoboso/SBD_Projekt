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
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime OdGodziny { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH-mm}", ApplyFormatInEditMode = true)]
        public DateTime DoGodziny { get; set; }
    }
}
