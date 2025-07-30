using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]

public class FoodsController : ControllerBase {

    private readonly ApplicationDbContext _context;

    public FoodsController(ApplicationDbContext context){
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSystemFood(){
        var foods = await _context.Foods.Where(f => f.UserId == null).ToListAsync();
        return Ok(foods);
    }

    [HttpPost]
    public async Task<IActionResult> AddFood([FromBody] Food newFood){


        _context.Foods.Add(newFood);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSystemFood),new {id = newFood.Id},newFood);
    }
}
