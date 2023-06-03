using AutoMapper;
using core.data.Entities;
using core.dto.AuthorsDto;
using core.dto.BooksDto;
using core.dto.PublisherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.dto.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();

            CreateMap<Author,AuthorDto>().ReverseMap();
            CreateMap<Publisher,PublisherDto>().ReverseMap();

        }
    }
}
