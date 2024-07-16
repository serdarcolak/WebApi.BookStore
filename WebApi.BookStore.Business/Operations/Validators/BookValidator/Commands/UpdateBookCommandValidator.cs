using FluentValidation;
using WebApi.BookStore.Business.Operations.BookOperations;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;

namespace WebApi.BookStore.Business.Validators.BookValidator.Commands;

public class UpdateBookCommandValidator: AbstractValidator<UpdateBookCommand.UpdateBookModel>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(command => command.GenreId).GreaterThan(0);
        RuleFor(command => command.Title).NotEmpty().MaximumLength(4);
    }
}