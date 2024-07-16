using FluentValidation;
using WebApi.BookStore.Business.Operations.GenreOperations.Commands;

namespace WebApi.BookStore.Business.Operations.Validators.GenreValidator.Commands;

public class DeleteGenreCommandValidator:AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreCommandValidator()
    {
        RuleFor(command => command.GenreId).GreaterThan(0);
    }
}