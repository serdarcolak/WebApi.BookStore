using AutoMapper;
using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.AuthorOperations.Queries;

public class GetAuthorsDetailQuery
{
    private readonly IBookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public int AuthorId { get; set; }
 
    public GetAuthorsDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public AuthorDetailViewModel Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x=> x.AuthorId == AuthorId);

        if (author is null)
            throw new InvalidOperationException("Yazar bulunamadı.");

        return _mapper.Map<AuthorDetailViewModel>(author);

    }
}

public class AuthorDetailViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}