using AutoMapper;
using FluentAssertions;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Business.Validators.BookValidator.Commands;
using WebApi.BookStore.Data.Context;
using WebApi.BookStore.Data.Model;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.Application.BookOperations.Commands;

public class CreateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
{
    

    [Theory]
    [InlineData("Lord Of The Rings", 0,0)]
    [InlineData("Lord Of The Rings", 0,1)]
    [InlineData("", 0,0)]
    [InlineData("", 100,1)]
    public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErros(string title, int pageCount,int genreId)
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookCommand.CreateBookModel()
        {
            Title = title, PageCount = pageCount, PublishDate = DateTime.Now.Date.AddYears(-1), GenreId = genreId
        };
        
        //act
        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);
        
        //assert
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public void WhenDateTimeEqualNowIsGiven_Validator_ShouldBeReturnError()
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookCommand.CreateBookModel()
        {
            Title = "Lord Of The Rings", PageCount = 100, PublishDate = DateTime.Now.Date, GenreId = 1
        };

        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    
    [Fact]
    public void WhenValidInoputsAreGiven_Validator_ShouldNotBeReturnError()
    {
        //arrange
        CreateBookCommand command = new CreateBookCommand(null, null);
        command.Model = new CreateBookCommand.CreateBookModel()
        {
            Title = "Mona Lisa Overdrive", PageCount = 360, PublishDate = DateTime.Now.Date, GenreId = 1
        };

        CreateBookCommandValidator validator = new CreateBookCommandValidator();
        var result = validator.Validate(command);
        result.Errors.Count.Should().BeGreaterThan(0);
    }
    
}