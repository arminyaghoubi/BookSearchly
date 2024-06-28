using BookSearchly.Application.Contracts.Persistence;
using BookSearchly.Application.Mappers;
using MediatR;

namespace BookSearchly.Application.Features.Book.Queries.Search;

public class SearchBookQueryHandler : IRequestHandler<SearchBookQuery, IEnumerable<SearchBookDto>>
{
    private readonly BookMapper _mapper;
    private readonly IBookRepository _bookRepository;

    public SearchBookQueryHandler(
        BookMapper mapper,
        IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<IEnumerable<SearchBookDto>> Handle(SearchBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.SearchAsync(request.Title);

        return _mapper.BooksToSearchBookDtos(books);
    }
}