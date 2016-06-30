using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;

namespace DataLayer
{
    public class NovelRepository : INovelRepository
    {
        private SqlConnection connection;

        public NovelRepository(string connectionString)
        {
            //TODO: connection string should not be hardcoded
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public bool DeleteNovel(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNovel(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel GetNovel(int id)
        {
            throw new NotImplementedException();
        }

        public Novel GetNovelByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Novel> GetNovels(int authorId)
        {
            var novels = new List<Novel>();

            using (var cmd = new SqlCommand("select * from novels where AuthorId=@authorId", connection))
            {

                cmd.Parameters.AddWithValue("@authorId", authorId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        novels.Add(GetNovelFromDataReader(reader));
                    }
                }
            }

            return novels;
        }

        private static Novel GetNovelFromDataReader(SqlDataReader reader)
        {
            var id = (int)reader["ID"];
            var title = (string)reader["Title"];
            var authorId = (int)reader["AuthorId"];
            var isRead = (bool)reader["IsRead"];

            var novel = new Novel
            {
                ID = id,
                Title = title,
                AuthorId = authorId,
                IsRead = isRead
            };

            return novel;
        }

        public Novel SaveNovel(Novel novel)
        {
            throw new NotImplementedException();
        }

        public Novel UpdateNovel(Novel novel)
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
                    connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~NovelRepository() {
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
