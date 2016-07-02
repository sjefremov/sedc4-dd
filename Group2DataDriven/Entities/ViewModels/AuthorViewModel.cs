using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public struct AuthorViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public NovelViewModel[] Novels { get; set; }

        public static AuthorViewModel FromModel(Author author)
        {
            return new AuthorViewModel
            {
                ID = author.ID,
                Name = author.Name,
                Novels = author.Novels.Select(NovelViewModel.FromModel).ToArray()
            };
        }
    }
}
