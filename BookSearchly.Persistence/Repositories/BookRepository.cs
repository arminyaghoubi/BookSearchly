using BookSearchly.Application.Contracts.Persistence;
using BookSearchly.Domain.Entities;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;

namespace BookSearchly.Persistence.Repositories;

internal class BookRepository : IBookRepository
{
    private readonly ElasticsearchClient _client;

    public BookRepository(ElasticsearchClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<Book>> SearchAsync(string title)
    {
        var response = await _client.SearchAsync<Book>(s => s
            .Query(q => q
                .Match(m => m
                    .Field(f => f.Title)
                    .Query(title)
                )
            )
        );

        if (!response.IsValidResponse)
        {
            throw new Exception();
        }

        var books = response.Documents;
        return books;
    }
}
