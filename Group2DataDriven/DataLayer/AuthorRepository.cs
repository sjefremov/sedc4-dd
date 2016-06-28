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
        private SqlConnection connection;

        public AuthorRepository()
        {
            connection = new SqlConnection(@"Server=PALMYRA02\SQLEXPRESS;Database=ScienceFictionDB;Trusted_Connection=True;");
            connection.Open();
        }

        public Author GetAuthorByName(string name)
        {
            using (SqlCommand cmd = new SqlCommand("select top 1 * from authors where Name like '%' + @name + '%'", connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                //var result = (int)cmd.ExecuteScalar();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    var resultId = (int)reader["ID"];
                    var resultName = (string)reader["Name"];
                    var birthDate = (DateTime)reader["DateOfBirth"];
                    var deathDate = reader["DateOfDeath"] as DateTime?;
                    
                    var author = new Author
                    {
                        ID = resultId,
                        Name = resultName,
                        BirthDate = birthDate,
                        DeathDate = deathDate
                    };

                    return author;
                }
                
            }
            
        }

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
            using (SqlCommand cmd = new SqlCommand("select * from authors where id = @id ", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                //var result = (int)cmd.ExecuteScalar();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

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

            }
            
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
