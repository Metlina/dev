using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDemo.Models
{
    public class Book : IEnumerable
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name="Pub Date")]
        [DataType(DataType.Date)]
        public DateTime PubDate { get; set; }

        public decimal Price { get; set; }
    }
}
