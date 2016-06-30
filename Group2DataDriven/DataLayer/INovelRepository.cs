using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface INovelRepository : IDisposable
    {
        Novel GetNovel(int id);
        IEnumerable<Novel> GetNovels(int authorId);

        Novel SaveNovel(Novel novel);

        Novel UpdateNovel(Novel novel);

        bool DeleteNovel(Novel novel);
        bool DeleteNovel(int id);

        Novel GetNovelByName(string name);
    }
}
