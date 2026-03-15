namespace IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Model;

public class SearchSnakeRequest
{
    public string Keyword { get; set; } = string.Empty;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
