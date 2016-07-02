using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public int? NovelCount { get; set; }

        public IEnumerable<Novel> Novels { get; set; }

        public override string ToString()
        {
            return $"#{ID}: {Name} ({BirthDate:dd/MM/yyyy} - {DeathDate:dd/MM/yyyy})";
        }
    }
}
