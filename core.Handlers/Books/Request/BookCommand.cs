using core.dto.BooksDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers.Books.Request
{
    public class BookCommand : IRequest<Guid>
    {
        public CreateBookDto CreateBookDto { get; set; }
    }
}
