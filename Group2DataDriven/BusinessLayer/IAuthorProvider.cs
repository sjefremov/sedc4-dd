using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IAuthorProvider : IDisposable
    {
        Author LoadAuthor(int id, bool loadNovels);

        Author RegisterDeath(Author author, DateTime deathDate, bool isUndead);

        Author Ressurect(Author author);
    }
}
