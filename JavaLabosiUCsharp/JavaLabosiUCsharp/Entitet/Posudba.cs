using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaLabosiUcsharpu.Entitet;

namespace JavaLabosiUCsharp.Entitet
{
    public class Posudba
    {
        private Clan clan;
        private Knjiga knjiga;
        private DateTime datetime;

        public Posudba(Clan clan, Knjiga knjiga, DateTime datetime)
        {
            this.clan = clan;
            this.knjiga = knjiga;
            this.datetime = datetime;
        }

        public Clan GetClan()
        {
            return this.clan;
        }

        public Knjiga GetKnjiga()
        {
            return this.knjiga;
        }

        public DateTime GetDateTime()
        {
            return this.datetime;
        }
    }
}
