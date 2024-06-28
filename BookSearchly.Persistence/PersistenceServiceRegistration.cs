using BookSearchly.Application.Contracts.Persistence;
using BookSearchly.Persistence.Repositories;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.DependencyInjection;

namespace BookSearchly.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
            .ServerCertificateValidationCallback((o, certificate, chain, errors) => true)
            .Authentication(new BasicAuthentication("elastic", "aw51oLM+O3IFKtG*_nY0"));

        var client = new ElasticsearchClient(settings);

        services.AddSingleton(client);

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
