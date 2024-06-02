using Microsoft.AspNetCore.Mvc;

namespace JsxWebApi.Controllers
{

    /// <summary>
    /// Custom jSilvestri.com BETA v 2024 Web API Demo Collection: Official <c>Weather Web API</c> Application.
    /// <para>
    /// ⚠️ IMPORTANT! ⚠️
    /// </para>
    /// <para>
    /// This is the initial release of the Custom jSilvestri.com BETA v 2024 Web API Demo Collection: Official <c>Weather Web API</c> Application. It includes only the essential resources by design.
    /// </para>
    /// <para>
    /// Many applications in the Custom jSilvestri.com BETA v 2024 Web API Demo Collection, such as the <c>Angular Web API Demo</c>, <c>Blazor Web API Demo</c>, <c>React Web API Demo</c>, and <c>Vue Web API Demo</c> Applications, will begin similarly. 
    /// </para>
    /// <para>This intentional minimalism allows for the demonstration of the step-by-step evolution of each application, from initial template to fully developed project, where it accesses the same Web API across all apps mentioned. This progression will cover various aspects including graphics, themes, imagery, CSS, JS, HTML, and related technologies, highlighting the process of maximizing creative asset re-use.
    /// </para>
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
