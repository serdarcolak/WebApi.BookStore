using AutoMapper;
using FluentAssertions;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands;

public class CreateBookCommandTests:IClassFixture<CommonTestFixture>
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookCommandTests(CommonTestFixture testFixture)
    {
        _context = testFixture.Context;
        _mapper = testFixture.Mapper;
    }
    
    [Fact]
    public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
    {
        //arrange (Hazırlık)
        var book = new Book()
        {
            Title = "WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100,
            PublishDate = new System.DateTime(1190, 01, 10), GenreId = 1
        };
        _context.Books.Add(book);
        _context.SaveChanges();

        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        command.Model = new CreateBookCommand.CreateBookModel() { Title = book.Title };

        //act & assert (Çalıştırma - Doğrulama)
        FluentActions
            .Invoking((() => command.Handle()))
            .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap zaten mevcut");

        //assert (Doğrulama)
    }
    
    [Fact]
    public void WhenValidInputsAreGiven_Book_ShouldBeCreated()
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(_context, _mapper);
        CreateBookCommand.CreateBookModel model = new CreateBookCommand.CreateBookModel()
            { Title = "Hobbit", PageCount = 1000, PublishDate = DateTime.Now.Date.AddYears(-10), GenreId = 1 };
        command.Model = model;
        
        //act
        FluentActions.Invoking(()=> command.Handle()).Invoke();
        
        //assert
        var book = _context.Books.SingleOrDefault(book => book.Title == model.Title);
        book.Should().NotBeNull();
        book.PageCount.Should().Be(model.PageCount);
        book.PublishDate.Should().Be(model.PublishDate);
        book.GenreId.Should().Be(model.GenreId);
    }
}