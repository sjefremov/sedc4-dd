using DataLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new SciFiContext();

            var author = new Author
            {
                Name = "Andy Weir",
                BirthDate = new DateTime(1968, 7, 7)
            };


            Console.WriteLine(author);
            context.Authors.Add(author);
            context.SaveChanges();
            Console.WriteLine(author);



            //var authors = context.Authors;

            //foreach (var author in authors)
            //{
            //    Console.WriteLine(author);
            //}

            //Console.WriteLine(authors.Count());
        }
    }
}
