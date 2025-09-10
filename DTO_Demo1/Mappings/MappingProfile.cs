using AutoMapper;
using DTO_Demo1.DTOs;
using DTO_Demo1.Models;

namespace DTO_Demo1.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //CreateMap<Book, BookDTO>();
            //CreateMap<BookDTO, Book>();

            //or
            CreateMap<Book,BookPostDTO>().ReverseMap();
            CreateMap<Book,BookDTO>().ReverseMap();
        }
        
    }
}
