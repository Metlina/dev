using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFXToASPNet.Models
{
    public class Clan
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string Ime { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public string Prezime { get; set; }

        [Required]
        [Display(Name = "OIB")]
        public string Oib { get; set; }
    }
}
