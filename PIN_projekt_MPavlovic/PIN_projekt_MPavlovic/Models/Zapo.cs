using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PIN_projekt_MPavlovic.Models
{
    public class Zapo
    {
        [Key]
        public int ZaposlenikID { get; set; }
        
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Zvanje { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Lokacija { get; set; }
    }
}
