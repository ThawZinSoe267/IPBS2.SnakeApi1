using IPBS2.SnakeApi.Database.AppDbContextModels;

namespace IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Model;

public class SearchSnakeResponse
{
    public int TotalCount { get; set; }
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<Snake> Data { get; set; } = new();
}
