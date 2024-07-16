using System.Net.Sockets;
using AutoMapper;
using WebApi.BookStore.Business.Operations.AuthorOperations.Commands;
using WebApi.BookStore.Business.Operations.AuthorOperations.Queries;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Business.Operations.BookOperations.Queries;
using WebApi.BookStore.Business.Operations.GenreOperations.Queries;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Business.Common;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBookCommand.CreateBookModel, Book>();
        CreateMap<Book, GetBooksDetailQuery.BooksViewDetailModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
        
        CreateMap<Book, GetBooksQuery.BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));

        CreateMap<Book, DeleteBookCommand.BookViewDeleteModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name + " " + src.Author.Surname));
        
        CreateMap<Genre, GenresViewModel>();
        CreateMap<Genre, GenresDetailViewModel>();
        
        CreateMap<CreateAuthorModel, Author>();
        CreateMap<Author, AuthorViewModel>();
        CreateMap<Author, AuthorDetailViewModel>();
    }
}
