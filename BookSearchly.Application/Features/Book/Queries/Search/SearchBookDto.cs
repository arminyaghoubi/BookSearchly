namespace BookSearchly.Application.Features.Book.Queries.Search;

public class SearchBookDto
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int PageCount { get; set; }
    public string ThumbnailUrl { get; set; }
    public string ShortDescription { get; set; }
}
