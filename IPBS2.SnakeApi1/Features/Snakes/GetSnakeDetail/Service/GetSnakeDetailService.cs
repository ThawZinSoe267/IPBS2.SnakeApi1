using IPBS2.SnakeApi.Database.AppDbContextModels;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakeDetail.Model;

namespace IPBS2.SnakeApi1.Features.Snakes.GetSnakeDetail.Service;

public class GetSnakeDetailService
{
    public static async Task<GetSnakeDetailResponse> ExecuteAsync(AppDbContext context, GetSnakeDetailRequest request)
    {
        var snake = await context.Snakes.FindAsync(request.Id);

        return new GetSnakeDetailResponse
        {
            Data = snake
        };
    }
}
