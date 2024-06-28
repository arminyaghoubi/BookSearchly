using BookSearchly.Persistence;
using BookSearchly.Application;
using BookSearchly.Application.Features.Book.Queries.Search;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices()
    .AddApplictionServices();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Book/Search", ([FromServices] IMediator mediator, [FromQuery] string title) =>
{
    var result = mediator.Send(new SearchBookQuery(title));
    return result;
})
.WithOpenApi();



app.Run();