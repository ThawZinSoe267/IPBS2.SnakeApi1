using Microsoft.AspNetCore.Mvc;
using IPBS2.SnakeApi.Database.AppDbContextModels;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakeDetail.Model;
using IPBS2.SnakeApi1.Features.Snakes.GetSnakeDetail.Service;

namespace IPBS2.SnakeApi1.Features.Snakes.GetSnakeDetail.Controller;

[Route("api/Snake")]
[ApiController]
public class GetSnakeDetailController : ControllerBase
{
    private readonly AppDbContext _context;

    public GetSnakeDetailController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSnakeDetail(int id)
    {
        var request = new GetSnakeDetailRequest { Id = id };
        var response = await GetSnakeDetailService.ExecuteAsync(_context, request);

        if (response.Data == null)
            return NotFound("Snake not found");

        return Ok(response.Data);
    }
}
