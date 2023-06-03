using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Entities
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;

        //Navigation Properties
        public List<Book> Books { get; set; }

    }
}
