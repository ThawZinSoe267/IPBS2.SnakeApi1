using Microsoft.AspNetCore.Mvc;
using IPBS2.SnakeApi.Database.AppDbContextModels;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakes.Model;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakes.Service;

namespace IPBS2.SnakeApi1.Features.Snakes.GetSnakes.Controller;

[Route("api/Snake")]
[ApiController]
public class GetSnakesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GetSnakesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSnakes([FromQuery] GetSnakesRequest request)
    {
        var response = await GetSnakesService.ExecuteAsync(_context, request);
        return Ok(response);
    }
}
