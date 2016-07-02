using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataLayer;

namespace BusinessLayer
{
    public class AuthorProvider : IAuthorProvider
    {
        private IAuthorRepository authorRepository;
        private INovelRepository novelRepository;
        public AuthorProvider(string connectionString)
        {
            authorRepository = new AuthorRepository(connectionString);
            novelRepository = new NovelRepository(connectionString);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            var authors = authorRepository.GetAllAuthors();

            foreach (var author in authors)
            {
                author.Novels = novelRepository.GetNovels(author.ID);
            }

            return authors;
        }
        public Author LoadAuthor(int id, bool loadNovels)
        {
            var author = authorRepository.GetAuthor(id);

            if (loadNovels)
            {
                author.Novels = novelRepository.GetNovels(id);
            }

            foreach (var novel in author.Novels)
            {
                novel.Author = author;
            }

            return author;
        }

        public Author RegisterDeath(Author author, DateTime deathDate, bool isUndead)
        {
            if (author.DeathDate != null && !isUndead)
            {
                throw new Exception("You can not die twice (unless undead)");
            }

            author.DeathDate = deathDate;
            authorRepository.UpdateAuthor(author);
            return author;
        }

        public Author Ressurect(Author author)
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
                    authorRepository.Dispose();
                    novelRepository.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~AuthorProvider() {
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
