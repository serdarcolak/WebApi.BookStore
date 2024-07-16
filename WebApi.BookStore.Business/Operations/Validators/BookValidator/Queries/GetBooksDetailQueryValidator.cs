using FluentValidation;
using WebApi.BookStore.Business.Operations.BookOperations.Queries;

namespace WebApi.BookStore.Business.Validators.BookValidator.Queries;

public class GetBooksDetailQueryValidator:AbstractValidator<GetBooksDetailQuery>
{
    public GetBooksDetailQueryValidator()
    {
        RuleFor(book => book.BookId).GreaterThan(0)
            .WithMessage("Book Id'si 0 olamaz");
    }
}