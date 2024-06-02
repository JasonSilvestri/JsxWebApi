namespace JsxWebApi
{

    /// <summary>
    /// Custom jSilvestri.com BETA v 2024 Web API Demo Collection: Official <c>Weather Web API</c> Application Sample Service.
    /// <para>
    /// ⚠️ IMPORTANT! ⚠️
    /// </para>
    /// <para>
    /// This is the initial release of the Custom jSilvestri.com BETA v 2024 Web API Demo Collection: Official <c>Weather Web API</c> Application. It includes only a sample with this release (by design).
    /// </para>
    /// <para>
    /// Many applications in the Custom jSilvestri.com BETA v 2024 Web API Demo Collection, such as the <c>Angular Web API Demo</c>, <c>Blazor Web API Demo</c>, <c>React Web API Demo</c>, and <c>Vue Web API Demo</c> Applications, will begin using this service in very similar situations. 
    /// </para>
    /// </summary>
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
