using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            var connectionString = ConfigurationManager.ConnectionStrings["scifi-database"].ConnectionString;
            using (var authorProvider = new AuthorProvider(connectionString))
            {
                //while (true)
                //{
                //int authorId = int.Parse(Console.ReadLine());
                //var author = a.GetAuthor(authorId);
                ////var name = Console.ReadLine();
                ////var author = a.GetAuthorByName(name);
                //Console.WriteLine(author);
                //}


                var allAuthors = authorProvider.GetAllAuthors();
                foreach (var author in allAuthors)
                {
                    Console.WriteLine(author);
                }

                //var author = new Author
                //{
                //    Name = "Pavle-test",
                //    BirthDate = new DateTime(1942, 9, 10),
                //    DeathDate = new DateTime(1992, 9, 10)
                //};

                //authorProvider.SaveAuthor(author);

                //if (authorProvider.DeleteAuthor(author))
                //{
                //    Console.WriteLine("Deleted successfully");
                //}
                //else
                //{
                //    Console.WriteLine("Not deleted");
                //}

                //var author = authorProvider.LoadAuthor(166, true);

                //Console.WriteLine(author);

                //foreach (var novel in author.Novels)
                //{
                //    Console.WriteLine(novel);
                //}


            }

        }
    }
}
