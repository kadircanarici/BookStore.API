using AutoMapper;
using BookStore.API.Application.AuthorOperations.Commands.CreateAuthor;
using BookStore.API.Application.AuthorOperations.Queries.GetAuthorDetail;
using BookStore.API.Application.AuthorOperations.Queries.GetAuthors;
using BookStore.API.Application.BookOperations.Queries.GetBookDetail;
using BookStore.API.Application.BookOperations.Queries.GetBooks;
using BookStore.API.Entities;
using static BookStore.API.Application.BookOperations.Commands.CreateBook.CreateBookCommand;
using static BookStore.API.Application.GenreOperations.Queries.GetGenreDetail.GetGenreDetailQuery;
using static BookStore.API.Application.GenreOperations.Queries.GetGenres.GetGenresQuery;

namespace BookStore.API.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book,BookDetailViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name));
            CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => (src.Genre.Name)));
            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();


            CreateMap<Author, AuthorViewModel>();
            CreateMap<Author, AuthorDetailViewModel>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src.Book.Title));

            CreateMap<CreateAuthorModel, Author>();

        }
    }
}
