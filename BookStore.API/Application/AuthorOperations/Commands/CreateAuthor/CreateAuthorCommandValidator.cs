using FluentValidation;

namespace BookStore.API.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.LastName).MinimumLength(2).NotEmpty();
            RuleFor(x => x.Model.BookId).NotEmpty().GreaterThan(0);
        }
    }
}
