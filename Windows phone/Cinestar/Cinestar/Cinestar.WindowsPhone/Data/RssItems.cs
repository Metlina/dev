using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinestar.Data
{
    class RssItems
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string OriginalName { get; set; }

        public string Director { get; set; }

        public string Actors { get; set; }

        public string Duration { get; set; }

        public string Year { get; set; }

        public string Genre { get; set; }

        public string Poster { get; set; }

        public string Guid { get; set; }

        public string Reservation { get; set; }         //link za opcenito rezervacije
        
        public string DateOfScreening { get; set; }
        
        public string Screening { get; set; }           //link za rezervaciju za odredeni film
        
        public string Images { get; set; }
        
        public string Trailer { get; set; }
    }
}
