using FluentValidation;
using WebApi.BookStore.Business.Operations.GenreOperations.Commands;

namespace WebApi.BookStore.Business.Operations.Validators.GenreValidator.Commands;

public class CreateGenreCommandValidator:AbstractValidator<CreateGenreCommand>
{
    public CreateGenreCommandValidator()
    {
        RuleFor(command => command.Model.Name)
            .NotEmpty().WithMessage("Bu alan dolu olmak zorundadır.")
            .MaximumLength(4).WithMessage("4 Karakterden fazla olamaz.");
    }
}