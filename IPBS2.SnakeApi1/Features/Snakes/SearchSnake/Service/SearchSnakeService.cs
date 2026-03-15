using IPBS2.SnakeApi.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;
using IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Model;

namespace IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Service;

public class SearchSnakeService
{
    public static async Task<SearchSnakeResponse> ExecuteAsync(AppDbContext context, SearchSnakeRequest request)
    {
        var query = context.Snakes
            .Where(s =>
                s.EngName.Contains(request.Keyword) ||
                s.Mmname.Contains(request.Keyword));

        var total = await query.CountAsync();

        var data = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new SearchSnakeResponse
        {
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize,
            Data = data
        };
    }
}
