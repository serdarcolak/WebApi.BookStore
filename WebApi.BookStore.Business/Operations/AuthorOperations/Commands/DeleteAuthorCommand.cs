using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Business.Operations.AuthorOperations.Commands;

public class DeleteAuthorCommand
{
    private readonly BookStoreDbContext _dbContext;

    public DeleteAuthorCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public int AuthorId { get; set; }

    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);

        var authorBook = _dbContext.Books.SingleOrDefault(x => x.AuthorId == AuthorId);
        
        if (author is null)
            throw new InvalidOperationException("Yazar bulunamadı.");
        if (authorBook is not null)
            throw new InvalidOperationException("Silmek istediğin yazarın yayında kitabı bulunmaktadır. Silmek için lütfen ilk önce kitabı siliniz.");

        _dbContext.Authors.Remove(author);
        _dbContext.SaveChanges();
    }
}