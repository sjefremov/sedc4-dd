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

        public AuthorRepository(string connectionString)
        {
            //TODO: connection string should not be hardcoded
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public Author GetAuthorByName(string name)
        {
            using (SqlCommand cmd = new SqlCommand("select * from authors where Name=@name", connection))
            {
                cmd.Parameters.AddWithValue("@name", name);

                //var result = (int)cmd.ExecuteScalar();
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }

                    return GetAuthorFromDataReader(reader);
                }
                
            }
            
        }

        public bool DeleteAuthor(int id)
        {
            using (var cmd = new SqlCommand("delete from authors where ID=@id", connection))
            {
                cmd.Parameters.AddWithValue("@id", id);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteAuthor(Author author)
        {
            if (author != null && author.ID == 0)
            {
                author = GetAuthorByName(author.Name);
            }

            if (author == null)
            {
                return false;
            }
            
            return DeleteAuthor(author.ID);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var authors = new List<Author>();

            using (var cmd = new SqlCommand(@"select a.*, COUNT(*) as NovelCount
                                    from Authors a
                                    inner
                                    join Novels n on n.AuthorID = a.ID
                                    group by a.ID, a.Name, a.DateOfBirth, a.DateOfDeath", connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        authors.Add(GetAuthorFromDataReader(reader, true));
                    }
                }
            }

            return authors;
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

                    return GetAuthorFromDataReader(reader);
                }

            }
            
        }

        private static Author GetAuthorFromDataReader(SqlDataReader reader, bool mapNovelCount = false)
        {
            var resultId = (int)reader["ID"];
            var name = (string)reader["Name"];
            var birthDate = (DateTime)reader["DateOfBirth"];
            var deathDate = reader["DateOfDeath"] as DateTime?;
            var novelCount = (mapNovelCount) ? (int)reader["NovelCount"] : (int?)null;

            var author = new Author
            {
                ID = resultId,
                Name = name,
                BirthDate = birthDate,
                DeathDate = deathDate,
                NovelCount = novelCount
            };

            return author;
        }

        public Author SaveAuthor(Author author)
        {
            if (author.ID != 0)
            {
                return UpdateAuthor(author);
            }

            if (ExistByName(author))
            {
                throw new ArgumentException("Author with that name exists!");
            }

            using (var cmd = new SqlCommand("insert into Authors (Name, DateOfBirth, DateOfDeath) values(@name, @birthDate, @deathDate)", connection))
            {
                cmd.Parameters.AddWithValue("@name", author.Name);
                cmd.Parameters.AddWithValue("@birthDate", author.BirthDate);
                cmd.Parameters.AddWithValue("@deathDate", author.DeathDate);

                cmd.ExecuteNonQuery();

                return GetAuthorByName(author.Name);
            }
        }

        public Author UpdateAuthor(Author author)
        {
            if (author.ID == 0)
            {
                return SaveAuthor(author);
            }

            throw new NotImplementedException();
        }

        private bool ExistByName(Author author)
        {
            using (var cmd = new SqlCommand("select count(*) from authors where Name=@name", connection))
            {
                cmd.Parameters.AddWithValue("@name", author.Name);

                return (int)cmd.ExecuteScalar() > 0;
            }
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
