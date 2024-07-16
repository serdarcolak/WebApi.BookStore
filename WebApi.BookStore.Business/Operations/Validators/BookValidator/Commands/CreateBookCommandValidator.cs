using FluentValidation;
using WebApi.BookStore.Business.Operations.AuthorOperations.Queries;
using WebApi.BookStore.Business.Operations.BookOperations.Commands;
using WebApi.BookStore.Data.Model;

namespace WebApi.BookStore.Business.Validators.BookValidator.Commands;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(command => command.Model.Title)
            .NotEmpty().WithMessage("Title alanı boş bırakılamaz")
            .MaximumLength(50).WithMessage("Title alanı en fazla 50 karakter olabilir");

        RuleFor(command => command.Model.PageCount)
            .NotEmpty().WithMessage("PageCount alanı boş bırakalamaz");

        RuleFor(command => command.Model.GenreId)
            .NotEmpty().WithMessage("GenreId alanı boş bırakalamaz")
            .InclusiveBetween(1, 4).WithMessage("GenreId 1 ile 4 arasında olmalıdır");
        
        RuleFor(command => command.Model.AuthorId)
            .NotEmpty().WithMessage("AuthorId alanı boş bırakalamaz");
    }
}