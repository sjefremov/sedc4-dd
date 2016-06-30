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
            connection = new SqlConnection(@"Server=(localDB)\.\Kentico;Database=Scify2;Trusted_Connection=True;");
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                //for example large arrays set to null

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AuthorRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion


    }
}
