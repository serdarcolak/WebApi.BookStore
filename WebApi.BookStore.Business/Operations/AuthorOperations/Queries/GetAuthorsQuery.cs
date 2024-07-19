using AutoMapper;
using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.AuthorOperations.Queries;

public class GetAuthorsQuery
{
    private readonly IBookStoreDbContext _dbContext;

    private readonly IMapper _mapper;

    public GetAuthorsQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<AuthorViewModel> Handle()
    {
        var authors = _dbContext.Authors.ToList(); 
        List<AuthorViewModel> returnList = _mapper.Map<List<AuthorViewModel>>(authors);
        return returnList;
    }
}

public class AuthorViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
}