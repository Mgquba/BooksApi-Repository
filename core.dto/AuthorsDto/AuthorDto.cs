using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.dto.AuthorsDto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
    }
}
