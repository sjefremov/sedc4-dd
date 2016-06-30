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
            //var author = new Author
            //{
            //    ID = 1,
            //    Name = "GRR Martin",
            //    BirthDate = new DateTime(1951, 1, 1),
            //    DeathDate = null
            //};

            //Console.WriteLine(author);

            //Console.WriteLine("-------------");

            using (var a = new AuthorRepository())
            {
                //while (true)
                //{
                    int authorId = int.Parse(Console.ReadLine());
                    var author = a.GetAuthor(authorId);
                    //var name = Console.ReadLine();
                    //var author = a.GetAuthorByName(name);
                    Console.WriteLine(author);
                //}
            }
            
        }
    }
}
