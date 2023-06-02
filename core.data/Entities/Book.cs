using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.data.Entities
{
    public class Book
    {
        public Guid Id { get; set; }    
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string CoverUrl { get; set; } = string.Empty;
        public DateTime DateAdded { get; set; }
    }
}
