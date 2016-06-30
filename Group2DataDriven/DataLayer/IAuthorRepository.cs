using Entities;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public interface IAuthorRepository : IDisposable
    {
        Author GetAuthor(int id);
        IEnumerable<Author> GetAllAuthors();

        Author SaveAuthor(Author author);

        Author UpdateAuthor(Author author);

        bool DeleteAuthor(Author author);
        bool DeleteAuthor(int id);

        Author GetAuthorByName(string name);

    }
}