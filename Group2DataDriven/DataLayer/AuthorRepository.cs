using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AuthorRepository : IAuthorRepository
    {
        public bool DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAuthor(Author author)
        {
            return DeleteAuthor(author.ID);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Author GetAuthor(int id)
        {
            SqlConnection connection = new SqlConnection(@"Server=PALMYRA02\SQLEXPRESS;Database=ScienceFictionDB;Trusted_Connection=True;");
            connection.Open();

            SqlCommand cmd = new SqlCommand("select * from authors where id = " + id, connection);

            //var result = (int)cmd.ExecuteScalar();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var resultId = (int)reader["ID"];
                var name = (string)reader["Name"];
                var birthDate = (DateTime)reader["DateOfBirth"];
                var deathDate = reader["DateOfDeath"] as DateTime?;
                
                var author = new Author
                {
                    ID = resultId,
                    Name = name,
                    BirthDate = birthDate,
                    DeathDate = deathDate
                };

                return author;
            }
            else
            {
                return null;
            }

            //Console.WriteLine(result);

            return null;
            //connect to database
            //make query
            //send query 
            //get result
            //create author
        }

        public Author SaveAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Author UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
