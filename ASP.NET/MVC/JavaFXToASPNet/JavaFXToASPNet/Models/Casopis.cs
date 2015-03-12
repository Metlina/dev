using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JavaFXToASPNet.Models
{
    public class Casopis
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Naziv")]
        public string NazivPublikacije { get; set; }

        [Required]
        [Display(Name = "Godina")]
        public int GodinaIzdanjaPublikacije { get; set; }

        [Required]
        [Display(Name = "Mjesec")]
        public int MjesecIzdavanjaCasopisa { get; set; }

        [Required]
        [Display(Name = "Vrsta")]
        public string Vrsta { get; set; }

        [Required]
        [Display(Name = "Broj stranica")]
        public int BrojStanicaPublikacije { get; set; }

        public enum VrstaVrstaPublikacije
        {
            Elektronicka,
            Papirnata
        };

        //public Casopis()
        //{

        //}

        //public Casopis(int mjesecIzdavanjaCasopisa, string naziv, int godina, int broj, VrstaPublikacije vrsta)
        //    : base(naziv, godina, broj, vrsta, CijenaPoPrimjerku / broj)
        //{
        //    MjesecIzdavanjaCasopisa = mjesecIzdavanjaCasopisa;
        //}
    }
}