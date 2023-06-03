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
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public bool? IsRead { get; set; }
        public DateTime? DateRead { get; set; } = DateTime.UtcNow;
        public int? Rate { get; set; }
        public string? Genre { get; set; } 
        public string? AuthorName { get; set; } 
        public string? CoverUrl { get; set; } 
        public DateTime? DateAdded { get; set; }

        //Navigation properties
        public Guid? PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Author { get; set; }
    }
}
