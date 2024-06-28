using MediatR;

namespace BookSearchly.Application.Features.Book.Queries.Search;

public record SearchBookQuery(string Title) : IRequest<IEnumerable<SearchBookDto>>;