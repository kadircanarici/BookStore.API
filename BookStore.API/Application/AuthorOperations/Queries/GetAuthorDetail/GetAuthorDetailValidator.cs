using FluentValidation;

namespace BookStore.API.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailValidator:AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);
        }
    }
}
