using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApi.BookStore.Business.Operations.GenreOperations.Queries;
using WebApi.BookStore.Data.Context;

namespace WebApi.BookStore.Business.Operations.BookOperations.Queries;

public class GetBooksDetailQuery
{
    private readonly IBookStoreDbContext _dbContext;

    private readonly IMapper _mapper;
    private IValidator<GetGenreDetailQuery> _validatorImplementation;

    public int BookId { get; set; }
    
    public GetBooksDetailQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;

    }

    public BooksViewDetailModel Handle()
    {
        var book = 
            _dbContext.Books
                .Include(x=>x.Genre)
                .Include(x=>x.Author)
                .Where(book => book.Id == BookId).SingleOrDefault();
        
        if (book is null)
        {
            throw new InvalidOperationException("Kitap mevcut değil");
        }

        BooksViewDetailModel vm = _mapper.Map<BooksViewDetailModel>(book);
        //new BooksViewDetailModel();
        /*vm.Title = book.Title;
        vm.PageCount = book.PageCount;
        vm.Genre = ((GenreEnum)book.GenreId).ToString();
        vm.PublishDate = book.PublishDate.Date.ToString();*/
        
        return vm;
    }
    
    public class BooksViewDetailModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        
    }
    
}