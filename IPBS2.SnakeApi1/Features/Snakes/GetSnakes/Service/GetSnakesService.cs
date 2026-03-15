using IPBS2.SnakeApi.Database.AppDbContextModels;
using Microsoft.EntityFrameworkCore;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakes.Model;

namespace IPBS2.SnakeApi1.Features.Snakes.GetSnakes.Service;

public class GetSnakesService
{
    public static async Task<GetSnakesResponse> ExecuteAsync(AppDbContext context, GetSnakesRequest request)
    {
        var total = await context.Snakes.CountAsync();

        var snakes = await context.Snakes
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync();

        return new GetSnakesResponse
        {
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize,
            Data = snakes
        };
    }
}
