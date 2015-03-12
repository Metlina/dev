using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaLabosiUCsharp.Entitet;
using JavaLabosiUcsharpu.Entitet;

namespace JavaLabosiUcsharpu
{
    class Program
    {
        public static Knjiga UnesiteKnjiga()
        {
            string naziv, jezik, nazivIzdavac, drzavaIzdavaca;

            Console.WriteLine("Unesite naziv knjige:");
            naziv = Console.ReadLine();
            Console.WriteLine("Unesite jezik knjige:");
            jezik = Console.ReadLine();
            Console.WriteLine("Unesite izdavaca:");
            nazivIzdavac = Console.ReadLine();
            Console.WriteLine("Unesite drzavu izdavaca:");
            drzavaIzdavaca = Console.ReadLine();
            
            Izdavac izdavac = new Izdavac(nazivIzdavac, drzavaIzdavaca);
            Knjiga knjiga = new Knjiga(naziv, jezik, izdavac);
            return knjiga;
        }

        public static Clan UnesiteClan()
        {
            string ime, prezime, OIB;

            Console.WriteLine("Unesite OIB clana:");
            OIB = Console.ReadLine();
            Console.WriteLine("Unesite prezime clana");
            prezime = Console.ReadLine();
            Console.WriteLine("Unesite ime clana");
            ime = Console.ReadLine();

            Clan clan = new Clan(ime, prezime, OIB);
            return clan;
        }

        public static void IspisiKnjiga(Knjiga knjiga)
        {
            Console.WriteLine("Naziv knjige : " + knjiga.GetNazivKnjige());
            Console.WriteLine("Jezik knjige : " + knjiga.GetJezikKnjige());
            Console.WriteLine("Izdavac :  " + knjiga.GetIzdavac().GetNazivIzdavaca());
            Console.WriteLine("Drzava izdavaca : " + knjiga.GetIzdavac().GetDrzavaIzdavaca());

        }

        public static void Main(string[] args)
        {
            Knjiga knjiga1, knjiga2;
            Clan clan;
            int odabir;
            DateTime datiuTime = new DateTime();

            Console.WriteLine("Unos 1. knjige:");
            knjiga1 = UnesiteKnjiga();

            Console.WriteLine("Unos 2. knjige:");
            knjiga2 = UnesiteKnjiga();

            Console.WriteLine("Unos clana");
            clan = UnesiteClan();

            Console.WriteLine("Odaberite knjigu:");
            Console.WriteLine("1) " + knjiga1.GetNazivKnjige());
            Console.WriteLine("2) " + knjiga2.GetNazivKnjige());
            odabir = Console.Read();

            Console.WriteLine("Stanje posudbe: ");
            if (odabir == 1)
            {
                IspisiKnjiga(knjiga1);
            }
            else if (odabir == 2)
            {
                IspisiKnjiga(knjiga2);
            }

            Console.WriteLine("Prezime : " + clan.GetPrezime());
            Console.WriteLine("Ime : " + clan.GetIme());
            Console.WriteLine("OIB : "+ clan.GetOIB());
            Console.WriteLine("Datum posudbe : " + datiuTime.GetDateTimeFormats().ToString());
        }
    }
}
