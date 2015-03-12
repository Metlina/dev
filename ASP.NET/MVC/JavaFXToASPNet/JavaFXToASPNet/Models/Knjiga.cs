using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFXToASPNet.Models
{
    public class Knjiga
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        public string NazivPublikacije { get; set; }

        [Required]
        [Display(Name = "Vrsta")]
        public string Vrsta { get; set; }

        [Required]
        [Display(Name = "Godina")]
        //[DataType(DataType.Date)]
        //[StringLength(4, MinimumLength = 4, ErrorMessage = "Must be 4")]
        //[Range(4, 4, ErrorMessage = "Must be 4")]
        public int GodinaIzdanjaPublikacije { get; set; }

        [Required]
        [Display(Name = "Jezik")]
        public string JezikProp { get;  set; }
       
        [Required]
        [Display(Name = "Broj stranica")]
        public int BrojStanicaPublikacije { get; set; }

        [Required]
        [Display(Name = "Izdavac")]
        public string NazivIzdavaca { get; set; }

        public enum VrstaPublikacije
        {
            Elektronicka,
            Papirnata
        };

        public enum Jezik
        {
            Hrvatski,
            Engleski,
            Njemacki,
            Francuski,
            Talijanski,
            Ruski,
            Kineski
        };

        //public Izdavac Izdavac { get;  set; }

        //public bool Raspolozivost { get;  set; }

        //public Knjiga()
        //{

        //}

        //public Knjiga(Izdavac izdavac, Jezik jezik, bool raspolozivost, string naziv, int godina, int broj, VrstaPublikacije vrsta, double cijenaPoStranici)
        //    : base(naziv, godina, broj, vrsta, cijenaPoStranici)
        //{
        //    Izdavac = izdavac;
        //    this.Jezik = jezik;
        //    this.Raspolozivost = true;
        //}
    }
}
