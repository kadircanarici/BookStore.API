using AutoMapper;
using BookStore.API.Application.BookOperations.Queries.GetBookDetail;
using BookStore.API.Application.BookOperations.Queries.GetBooks;
using BookStore.API.Entities;
using static BookStore.API.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.API.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;

namespace BookStore.API.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Genre, GenresViewModel>();
        }
    }
}
