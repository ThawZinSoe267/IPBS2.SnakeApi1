using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPBS2.SnakeApi.Database.AppDbContextModels;

namespace IPBS2.SnakeApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnakeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SnakeController(AppDbContext context)
        {
            _context = context;
        }

        // =============================
        // 1. Snake List with Pagination
        // =============================
        [HttpGet]
        public async Task<IActionResult> GetSnakes(int page = 1, int pageSize = 10)
        {
            var total = await _context.Snakes.CountAsync();

            var snakes = await _context.Snakes
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                TotalCount = total,
                Page = page,
                PageSize = pageSize,
                Data = snakes
            });
        }

        // =============================
        // 2. Snake Detail
        // =============================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSnakeDetail(int id)
        {
            var snake = await _context.Snakes.FindAsync(id);

            if (snake == null)
                return NotFound("Snake not found");

            return Ok(snake);
        }

        // =============================
        // 3. Search + Pagination
        // =============================
        [HttpGet("search")]
        public async Task<IActionResult> SearchSnake(string keyword, int page = 1, int pageSize = 10)
        {
            var query = _context.Snakes
                .Where(s =>
                    s.EngName.Contains(keyword) ||
                    s.Mmname.Contains(keyword));

            var total = await query.CountAsync();

            var data = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                TotalCount = total,
                Page = page,
                PageSize = pageSize,
                Data = data
            });
        }
    }
}