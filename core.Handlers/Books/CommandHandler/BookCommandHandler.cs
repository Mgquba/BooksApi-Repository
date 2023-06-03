using AutoMapper;
using core.data.Entities;
using core.data.Repositories.Interfaces;
using core.dto.BooksDto;
using core.Handlers.Books.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers.Books.CommandHandler
{
    public class BookCommandHandler : IRequestHandler<BookCommand, Guid>
    {
        private readonly IRepository<Book> _books;
        private readonly IMapper _mapper;
        public BookCommandHandler(IRepository<Book> books, IMapper mapper)
        {
            _books= books;
            _mapper= mapper;
        }
        public async Task<Guid> Handle(BookCommand request, CancellationToken cancellationToken)
        {
            Book book = BookEntity(request.CreateBookDto);
            await _books.AddAsync(book);
            await _books.UnitOfWork.SaveEntitiesAsync();

            return Guid.Empty;

        }
        private static Book BookEntity(CreateBookDto createBookDto)
        {
            return new Book
            {
                Id = createBookDto.Id,
                Title = createBookDto.Title,
                Description = createBookDto.Description,
                Genre = createBookDto.Genre,
                CoverUrl = createBookDto.CoverUrl,



            };
        }
    }
}
