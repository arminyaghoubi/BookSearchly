using BookSearchly.Domain.Entities;

namespace BookSearchly.Application.Contracts.Persistence;

public interface IBookRepository
{
    Task<IEnumerable<Book>> SearchAsync(string title);
}
