using AutoMapper;
using BookStore.API.BookOperations.GetBookDetail;
using BookStore.API.BookOperations.GetBooks;
using static BookStore.API.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.API.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
