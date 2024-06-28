using Riok.Mapperly.Abstractions;
using BookSearchly.Application.Features.Book.Queries.Search;
using BookSearchly.Domain.Entities;

namespace BookSearchly.Application.Mappers;

[Mapper]
public partial class BookMapper
{
    public partial IEnumerable<SearchBookDto> BooksToSearchBookDtos(IEnumerable<Book> book);
}
