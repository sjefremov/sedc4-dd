using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ViewModels
{
    public struct NovelViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public bool IsRead { get; set; }

        public static NovelViewModel FromModel(Novel novel)
        {
            return new NovelViewModel
            {
                ID = novel.ID,
                Title = novel.Title,
                IsRead = novel.IsRead
            };
        }
    }
}
