using FluentValidation;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;

namespace WebApi.BookStore.Business.Validators.BookValidator.Commands;

public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(book => book.BookId).GreaterThan(0)
            .WithMessage("Book Id'si 0 olamaz");
    }
}