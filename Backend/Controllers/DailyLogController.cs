using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DailyLogController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DailyLogController(ApplicationDbContext context){
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> LogFood([FromBody] CreateLogDto logDto){
        if (!await _context.Foods.AnyAsync(f => f.Id == logDto.FoodId)) return NotFound("Food item not found");
        var dailyLog = new DailyLog{
            UserId = 1,
            FoodId = logDto.FoodId,
            QuantityInGrams = logDto.QuantityInGrams,
            MealType = logDto.Mealtype,
            Date = logDto.Date.ToUniversalTime().Date
        };

        _context.DailyLogs.Add(dailyLog);
        await _context.SaveChangesAsync();
        return Ok(dailyLog);
    }

    [HttpGet("summary/{date}")]
    public async Task<IActionResult> GetDailySummary(DateTime date)
    {
        var logsForDay = await _context.DailyLogs
        .Include(log => log.Food)
        .Where(log => log.UserId == 1 && log.Date == date.ToUniversalTime().Date)
        .ToListAsync();

        var summary = new
        {
            Date = date.ToString("yyyy-MM-dd"),
            TotalCalories = Math.Round(logsForDay.Sum(l => l.QuantityInGrams/100 * l.Food!.CaloriesPer100g)),
            TotalProtein = Math.Round(logsForDay.Sum(l => l.QuantityInGrams/100 * l.Food!.ProteinPer100g)),
            TotalFat = Math.Round(logsForDay.Sum( l=> l.QuantityInGrams/100 * l.Food!.FatPer100g)),
            Meals = logsForDay
            .GroupBy(log => log.MealType)
            .ToDictionary(
                group => group.Key.ToString(),
                group => group.Select( log => new {
                    FoodName = log.Food!.Name,
                    Quantity = log.QuantityInGrams,
                    Protein = Math.Round(log.QuantityInGrams/100 * log.Food.ProteinPer100g),
                    Fat = Math.Round(log.QuantityInGrams/100 * log.Food.FatPer100g),
                    Calories = Math.Round(log.QuantityInGrams/100 * log.Food.CaloriesPer100g)
                }).ToList()
            )
        };
        return Ok(summary);
    }
}
