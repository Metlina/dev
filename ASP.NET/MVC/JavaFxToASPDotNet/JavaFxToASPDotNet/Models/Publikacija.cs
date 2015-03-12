using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaFxToASPDotNet.Models
{
    public class Publikacija
    {
        //public int ID { get; set; }

        protected string NazivPublikacije { get; private set; }
        protected int GodinaIzdanjaPublikacije { get; private set; }
        protected int BrojStanicaPublikacije { get; private set; }
        protected VrstaPublikacije Publikacije { get; private set; }
        protected double Cijena { get; private set; }

        public Publikacija()
        {
            
        }

        public Publikacija(string naziv, int godina, int broj, VrstaPublikacije vrsta, double cijenaPoStranici)
        {
            NazivPublikacije = naziv;
            GodinaIzdanjaPublikacije = godina;
            BrojStanicaPublikacije = broj;
            Publikacije = vrsta;
            Cijena = Izracunaj(broj, vrsta, cijenaPoStranici);
        }

        public double Izracunaj(int broj, VrstaPublikacije vrsta, double cijenaPoStranici)
        {
            throw new NotImplementedException();
        }

        //public string GetNaziv()
        //{
        //    return NazivPublikacije;
        //}

        //public int GetGodinaIzdanja()
        //{
        //    return GodinaIzdanjaPublikacije;
        //}

        //public int GetBrojStranica()
        //{
        //    return BrojStanicaPublikacije;
        //}

        //public double GetCijena()
        //{
        //    return Cijena;
        //}

        //public VrstaPublikacije GetVrstaPublikacije()
        //{
        //    return Publikacije;
        //}
    }
}
