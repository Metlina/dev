using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JavaFxToASPDotNet.Models
{
    public class Posudba
    {
        public int ID { get; set; }

        public Clan Clan { get; private set; }
        public Publikacija Publikacija { get; private set; }
        public DateTime DateTime { get; private set; }

        public Posudba()
        {
            
        }

        public Posudba(Clan clan, Publikacija publikacija, DateTime dateTime)
        {
            Clan = clan;
            Publikacija = publikacija;
            DateTime = dateTime;
        }
    }
}