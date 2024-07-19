using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Business.Operations.BookOperations.Commands;

public class DeleteBookCommand
{
    private readonly IBookStoreDbContext _dbContext;

    private readonly IMapper _mapper;
    
    public int BookId { get; set; }

    public DeleteBookCommand(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public BookViewDeleteModel Handle()
    {
        var book = _dbContext.Books
            .Include(x => x.Genre)
            .Include(x => x.Author)
            .SingleOrDefault(x => x.Id == BookId);
        
        if (book is null)
        {
            throw new InvalidOperationException("Silinecek Kitap mevcut değil");
        }

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();

        BookViewDeleteModel vm = _mapper.Map<BookViewDeleteModel>(book);
        /*vm.Title = book.Title;
        vm.PageCount = book.PageCount;
        vm.Genre = ((GenreEnum)book.GenreId).ToString();
        vm.PublishDate = book.PublishDate.Date.ToString();*/
        return vm;
    }


    public class BookViewDeleteModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        
        public string Author { get; set; }
    }
}
    