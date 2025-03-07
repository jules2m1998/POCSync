using Microsoft.AspNetCore.Mvc;
using POCSync.Application.EventHandlers.PackagesEvents.CreatePackage;
using POCSync.Domain.Services;

namespace POCSync.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, IEventEmitter<CreatePackageEvent> emitter) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    private readonly ILogger<WeatherForecastController> _logger = logger;
    private readonly IEventEmitter<CreatePackageEvent> _emitter = emitter;

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var @event = new CreatePackageEvent
        {
            Id = Guid.NewGuid(),
        };
        var result = await _emitter.Send(@event);
        return [.. Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })];
    }
}
