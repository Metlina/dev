using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookDemo.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookDBContext>
    {
        protected override void Seed(BookDBContext context)
        {
            context.Books.Add(new Book()
            {
                Name = "Teach Yourself C++ In 21 Days",
                PubDate = new DateTime(1995, 1, 1),
                Price = 29.95m
            });

            context.Books.Add(new Book()
            {
                Name = "Programming C#",
                PubDate = new DateTime(2000, 1, 1),
                Price = 49.95m
            });

            context.Books.Add(new Book()
            {
                Name = "Pro Windows 8 With XAML and C#",
                PubDate = new DateTime(2014, 1, 1),
                Price = 39.95m
            });

            base.Seed(context);
        }
    }
}