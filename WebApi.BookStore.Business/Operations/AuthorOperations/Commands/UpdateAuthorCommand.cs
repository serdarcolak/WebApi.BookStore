using System.Reflection.Metadata;
using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.AuthorOperations.Commands;

public class UpdateAuthorCommand
{
    private readonly IBookStoreDbContext _dbContext;
    
    public UpdateAuthorModel Model { get; set; }
    
    public int AuthorId { get; set; }
    
    public UpdateAuthorCommand(IBookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Yazar bulunamadı.");

        author.Name = Model.Name != default ? Model.Name : author.Name;
        author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
        author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;

        _dbContext.SaveChanges();
    }
    
    
}

public class UpdateAuthorModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}