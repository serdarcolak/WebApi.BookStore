using FluentValidation;
using Microsoft.VisualBasic;
using WebApi.BookStore.Business.Operations.GenreOperations.Commands;

namespace WebApi.BookStore.Business.Operations.Validators.GenreValidator.Commands;

public class UpdateGenreCommandValidator:AbstractValidator<UpdateGenreCommand>
{
    public UpdateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .MinimumLength(4)
            .When(X => X.Model.Name != string.Empty);
    }
}