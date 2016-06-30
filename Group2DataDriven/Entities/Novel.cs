using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Novel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }

        public bool IsRead { get; set; }

        public Author Author { get; set; }

        public override string ToString()
        {
            return $"#{ID} {Title}"; 
        }
    }
}
