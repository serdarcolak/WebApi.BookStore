using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.BookOperations.Commands;

public class UpdateBookCommand
{
    private readonly BookStoreDbContext _dbContext;
    public UpdateBookModel BookModel { get; set; }
    public int BookId { get; set; }

    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);
         
        if (book is null)
        {
            throw new InvalidOperationException("Kitap mevcut değil");
        }

        book.GenreId = BookModel.GenreId != default ? BookModel.GenreId : book.GenreId;
        book.AuthorId = BookModel.AuthorId != default ? BookModel.AuthorId : book.AuthorId;
        book.PageCount = BookModel.PageCount != default ? BookModel.PageCount : book.PageCount;
        book.PublishDate = BookModel.PublishDate != default ? BookModel.PublishDate : book.PublishDate;
        book.Title = BookModel.Title != default ? BookModel.Title : book.Title;
        
        _dbContext.SaveChanges();
    }
    
    public class UpdateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}