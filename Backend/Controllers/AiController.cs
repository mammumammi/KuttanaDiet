using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("api/[controller]")]
public class AiController : ControllerBase 
{
    private readonly string _httpClient;
    private readonly string _apiKey;

    public AiController(IConfiguration configuration){
        _httpClient = new HttpClient();
        _apiKey = configuration["Gemini : ApiKey"];
    }

    [HttpGet("nutrition")]
    public async Task<IActionResult> GetNutritionInfo([FromQuery] string foodName)
    {
        if (string.IsNullOrWhiteSpace(foodName)){
            return BadRequest("Food Name Cannot be empty");
        }

        i

        var geminiUrl = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={_apiKey}";
        


    }
}