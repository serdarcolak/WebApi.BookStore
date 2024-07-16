using FluentValidation;
using WebApi.BookStore.Business.Operations.GenreOperations.Queries;

namespace WebApi.BookStore.Business.Operations.Validators.GenreValidator.Queries;

public class GetGenreDetailQueryValidator: AbstractValidator<GetGenreDetailQuery>
{
    public GetGenreDetailQueryValidator()
    {
        RuleFor(query => query.GenreId).GreaterThan(0);
    }
}