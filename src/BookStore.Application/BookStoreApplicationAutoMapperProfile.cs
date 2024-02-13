using AutoMapper;
using BookStore.Books;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
         CreateMap<Book, BookDto>();
         CreateMap<CreateUpdateBookDto, Book>();
    }

}
