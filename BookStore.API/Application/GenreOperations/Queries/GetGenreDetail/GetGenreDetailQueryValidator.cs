﻿using FluentValidation;

namespace BookStore.API.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);
        }
    }
}
