using Microsoft.AspNetCore.Mvc;
using IPBS2.SnakeApi.Database.AppDbContextModels;
using IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Model;
using IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Service;

namespace IPBS2.SnakeApi1.Features.Snakes.SearchSnake.Controller;

[Route("api/Snake")]
[ApiController]
public class SearchSnakeController : ControllerBase
{
    private readonly AppDbContext _context;

    public SearchSnakeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchSnake([FromQuery] SearchSnakeRequest request)
    {
        var response = await SearchSnakeService.ExecuteAsync(_context, request);
        return Ok(response);
    }
}
