using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Entities
{
    public class Author
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        public List<Book_Author> Book_Author { get; set; }
    }
}
